using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fight : MonoBehaviour
{

    public GameObject startFightPanel;
    public static UserM currentEnemy;
    public static UserM[] usersS = new UserM[dataLoader.usersLength];
    public Text scoreText;
    
    public static void updateUsersLvlArray ()
    {
        for (int i = 0; i < dataLoader.usersLength; i++)
        {
            usersS[i] = dataLoader.usersM[i];
        }
        for (int i = 0; i < dataLoader.usersLength - 1; i++)
        {
            for (int j = i + 1; j < dataLoader.usersLength; j++)
            {
                if (usersS[i].p_xp < usersS[j].p_xp)
                {
                    UserM aux = new UserM();
                    aux = usersS[i];
                    usersS[i] = usersS[j];
                    usersS[j] = aux;
                }
            }
        }
    }

    public void matchmaking ()
    {
        StartCoroutine(matchmakingIE());
    }
    public IEnumerator matchmakingIE ()
    {
        declarations.loadingPanel.SetActive(true);
        yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        updateUsersLvlArray();

        int posCU = 0;
        int posInit;
        int posFinal;

        for (int i = 0; i < dataLoader.usersLength; i++)
        {
            if (usersS[i].p_id == login.currentUser.p_id)
            {
                posCU = i;
                break;
            }
        }
        // Preferably, players will fight with players of this level (highest smaller level)
        int wantedLvl = declarations.playerLvl(usersS[posCU].p_xp);
        posInit = posCU - 1;
        if (posCU != 0)
        {
            for (int i = posCU - 1; declarations.playerLvl(usersS[i].p_xp) == wantedLvl && i > 0; i--)
            {
                posInit = i;
            }
        }
        else
        {
            posInit = 0;
        }
        posFinal = posCU + 1;
        if (posCU != dataLoader.usersLength - 1)
        {
            for (int i = posCU + 1; declarations.playerLvl(usersS[i].p_xp) == wantedLvl && i + 1 < dataLoader.usersLength; i++)
            {
                posFinal = i;
            }
        }
        else
        {
            posFinal = posCU;
        }
        int enemyId = usersS[UnityEngine.Random.Range(posInit, posFinal + 1)].p_id;
        while (enemyId == login.currentUser.p_id)
        {
            enemyId = usersS[UnityEngine.Random.Range(posInit, posFinal + 1)].p_id;
        }
        enemyId--; // TRUST ME

        print("You are about to be matched against " + dataLoader.usersM[enemyId].p_name);

        if (dataLoader.usersM[enemyId].p_class == 0)
        {
            matchmaking();
        }

        else
        {
            print("You were matched against " + dataLoader.usersM[enemyId].p_name);
            declarations.loadingPanel.SetActive(false);
            startFight(enemyId);
        }
    }
    
    public void startFight (int enemyId)
    {
        currentEnemy = dataLoader.usersM[enemyId];
        StartCoroutine(addGameIE());
        StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE());
        startFightPanel.SetActive(false);
        declarations.topBarFight.SetActive(true);
        declarations.playerModel = Instantiate(declarations.classes[login.currentUser.p_class - 1].c_model, new Vector3(0f, 2f, -30f), Quaternion.Euler(0f, 0f, 0f));
        declarations.enemyModel = Instantiate(declarations.classes[currentEnemy.p_class - 1].c_model, new Vector3(0f, 2f, 20f), Quaternion.Euler(180f, 0f, 180f));
        declarations.playerModel.transform.localScale = new Vector3(7f, 7f, 7f);
        declarations.enemyModel.transform.localScale = new Vector3(7f, 7f, 7f);
        declarations.playerHP = login.currentUser.p_def;
        declarations.enemyHP = currentEnemy.p_def;
        updateHP();
        updatePossibleOutcomes();
    }

    public void changeTurns (int moveId)
    {
        StartCoroutine(changeTurnsIE(moveId));
    }
    public IEnumerator changeTurnsIE (int moveId)
    {
        
        if (declarations.playerHP > 0f && declarations.enemyHP > 0f)
        {
            scoreText.text = "";
            declarations.scoreText.text = "";
            manipulatePanels(false);
            declarations.score = 0;
            declarations.difficulty = moveId;
            if (moveId == 1)
            {
                yield return (StartCoroutine(spawnArrows()));
                //yield return (StartCoroutine(declarations.playerModel.GetComponent<Animation_1>().walkAndPunch(1)));
                declarations.enemyHP -= declarations.score * (declarations.classes[login.currentUser.p_class - 1].c_atk / 10.0f) / 100;
            }
            else if (moveId == 2)
            {
                yield return (StartCoroutine(spawnArrows()));
                //yield return (StartCoroutine(declarations.playerModel.GetComponent<Animation_1>().attack(login.currentUser.p_eqw, 1)));
                declarations.enemyHP -= (declarations.score / 2) * (login.currentUser.p_atk / 10.0f) / 100;
            }
            else
            {
                declarations.difficulty += declarations.possibleSkills[declarations.randomSkill].s_difficulty;
                yield return (StartCoroutine(spawnArrows()));
                //yield return (StartCoroutine(declarations.playerModel.GetComponent<Animation_1>().skill(declarations.possibleSkills[declarations.randomSkill].s_name)));
                declarations.enemyHP -= (declarations.score / 4) * (login.currentUser.p_atk / 10.0f + declarations.possibleSkills[declarations.randomSkill].s_dmg) / 100;
            }
            updateHP();
            if (declarations.enemyHP <= 0f)
            {
                yield return (StartCoroutine(finishGame(1)));
            }
            //declarations.playerHP -= currentEnemy.p_atk / 10;
            int move = 1;
            if (currentEnemy.p_eqw != 0)
            {
                move = 2;
                int z = 0;
                bool skillFound = false;
                for (int i = 0; i < declarations.skillsLength; i++)
                {
                    if (currentEnemy.p_knownSkills[i] == '1' && declarations.skills[i].s_weapon == currentEnemy.p_eqw)
                    {
                        declarations.enemyPossibleSkills[z++] = declarations.skills[i];
                        skillFound = true;
                        move = 3;
                    }
                }
                if (skillFound == true)
                {
                    declarations.enemyRandomSkill = (int)Math.Floor(UnityEngine.Random.Range(0f, z));
                }
            }
            int enemyMoveId = (int)Math.Floor(UnityEngine.Random.Range(1f, move + 1));
            if (enemyMoveId == 1)
            {
                //yield return (StartCoroutine(declarations.enemyModel.GetComponent<Animation_1>().walkAndPunch(-1)));
                float normalAttack = declarations.classes[currentEnemy.p_class - 1].c_atk / 10.0f;
                declarations.playerHP -= UnityEngine.Random.Range(normalAttack - (normalAttack / 10.0f), normalAttack);
            }
            else if (enemyMoveId == 2)
            {
                //yield return (StartCoroutine(declarations.enemyModel.GetComponent<Animation_1>().attack(currentEnemy.p_eqw, -1)));
                float normalAttack = currentEnemy.p_atk / 10.0f;
                declarations.playerHP -= UnityEngine.Random.Range(normalAttack - (normalAttack / 20.0f), normalAttack);
            }
            else if (enemyMoveId == 3)
            {
                //yield return (StartCoroutine(declarations.enemyModel.GetComponent<Animation_1>().skill(declarations.enemyPossibleSkills[declarations.enemyRandomSkill].s_name)));
                float normalAttack = currentEnemy.p_atk / 10.0f + declarations.enemyPossibleSkills[declarations.enemyRandomSkill].s_dmg;
                declarations.playerHP -= UnityEngine.Random.Range(normalAttack - (normalAttack / 40.0f), normalAttack);
            }
            else
            {
                print("NINO NINOO NINOOO");
            }
            updateHP();
            if (declarations.playerHP <= 0f)
            {
                yield return (StartCoroutine(finishGame(0)));
            }
            manipulatePanels(true);
            updatePossibleOutcomes();
        }
    }

    public IEnumerator waitForSeconds (float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);
        yield return wait;
    }

    public void manipulatePanels (bool q)
    {
        if (q == false)
        {
            declarations.turnPanel.transform.localScale = new Vector3(0f, 0f, 0f);
            for (int i = 0; i < 4; i ++)
            {
                declarations.grayArrows[i].SetActive(true);
            }
            scoreText.gameObject.SetActive(true);
            declarations.scoreText.gameObject.SetActive(true);
            declarations.scoreText.text = "0";
        }
        else
        {
            declarations.turnPanel.transform.localScale = new Vector3(1f, 1f, 1f);
            for (int i = 0; i < 4; i++)
            {
                declarations.grayArrows[i].SetActive(false);
            }
            scoreText.gameObject.SetActive(false);
            declarations.scoreText.gameObject.SetActive(false);
            declarations.scoreText.text = "";
        }
    }
    public void updateHP ()
    {
        if (declarations.playerHP <= 0)
        {
            declarations.playerHPText.text = "Your HP: Dead";
        }
        else
        {
            declarations.playerHPText.text = "Your HP: " + declarations.playerHP.ToString("F2");
        }
        if (declarations.enemyHP <= 0)
        {
            declarations.enemyHPText.text = currentEnemy.p_name + "'s HP: Dead";
        }
        else
        {
            declarations.enemyHPText.text = currentEnemy.p_name + "'s HP: " + declarations.enemyHP.ToString("F2");
        }
        
    }
    public void updatePossibleOutcomes ()
    {
        declarations.BAtext.text = "Deal up to: " + (declarations.classes[login.currentUser.p_class - 1].c_atk / 10.0f).ToString("F2");
        if (login.currentUser.p_eqw != 0)
        {
            declarations.WBAtext.text = "Deal up to: " + (login.currentUser.p_atk / 10.0f).ToString("F2");
            declarations.invisWBA.SetActive(false);
            int z = 0;
            bool skillFound = false;
            for (int i = 0; i < declarations.skillsLength; i ++)
            {
                if (login.currentUser.p_knownSkills[i] == '1' && declarations.skills[i].s_weapon == login.currentUser.p_eqw)
                {
                    declarations.possibleSkills[z++] = declarations.skills[i];
                    skillFound = true;
                }
            }
            if (skillFound == true)
            {
                declarations.invisWS.SetActive(false);
                declarations.randomSkill = (int)Math.Floor(UnityEngine.Random.Range(0f, z));
                declarations.WS_SkillNametext.text = declarations.possibleSkills[declarations.randomSkill].s_name;
                declarations.WStext.text = "Deal up to: " + (login.currentUser.p_atk / 10.0f + declarations.possibleSkills[declarations.randomSkill].s_dmg).ToString("F2");
            }
        }
    }

    public IEnumerator addGameIE ()
    {
        matchHistory.matchID = login.currentUser.p_played;
        matchHistory.player1ID = login.currentUser.p_id;
        matchHistory.player2ID = currentEnemy.p_id;
        matchHistory.won = 0;
        matchHistory.day = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        login.currentUser.p_played++;
        login.currentUser.p_cash += 10;
        login.currentUser.p_xp += 5;
        yield return StartCoroutine(Camera.main.GetComponent<matchHistory>().UploadGame());
    }
    public IEnumerator finishGame (int gameFinalStatus)
    {
        for (int i = 0; i < 4; i++)
        {
            declarations.grayArrows[i].SetActive(false);
        }
        declarations.topBarFight.SetActive(false);
        Destroy(declarations.playerModel);
        Destroy(declarations.enemyModel);
        manipulatePanels(true);
        if (gameFinalStatus == 1)
        {
            login.currentUser.p_won++;
            login.currentUser.p_cash += 50;
            login.currentUser.p_xp += 20;
            matchHistory.matchID = login.currentUser.p_played - 1;
            declarations.loadingPanel.SetActive(true);
            yield return StartCoroutine(Camera.main.GetComponent<matchHistory>().UpdateWonGame());

            declarations.wonPanel.SetActive(true);
            yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        }
        else
        {
            declarations.lostPanel.SetActive(true);
            yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        }
        declarations.turnPanel.SetActive(false);
    }

    public IEnumerator spawnArrows()
    {
        for (int i = 0; i < declarations.numberOfArrows; i ++)
        {
            declarations.arrowArray[i].deleted = true;
        }
        declarations.numberOfArrows = 0;
        if (declarations.difficulty == 1)
        {
            WaitForSeconds wait = new WaitForSeconds(0.45f);
            WaitForSeconds wait2 = new WaitForSeconds(6f);
            for (int i = 0; i < 20; i++)
            {
                int typeOfArrow = (int)Math.Floor(UnityEngine.Random.Range(0f, 3.999999f));
                if (typeOfArrow == 0)
                {
                    generateLeft();
                }
                else if (typeOfArrow == 1)
                {
                    generateUp();
                }
                else if (typeOfArrow == 2)
                {
                    generateDown();
                }
                else
                {
                    generateRight();
                }
                declarations.arrowArray[declarations.numberOfArrows - 1].deleted = false;
                yield return wait;
            }
            yield return wait2; 
        }
        else if (declarations.difficulty == 2)
        {
            WaitForSeconds wait = new WaitForSeconds(0.30f);
            WaitForSeconds wait2 = new WaitForSeconds(3f);
            for (int i = 0; i < 40; i++)
            {
                int typeOfArrow = (int)Math.Floor(UnityEngine.Random.Range(0f, 3.999999f));
                if (typeOfArrow == 0)
                {
                    generateLeft();
                }
                else if (typeOfArrow == 1)
                {
                    generateUp();
                }
                else if (typeOfArrow == 2)
                {
                    generateDown();
                }
                else
                {
                    generateRight();
                }
                declarations.arrowArray[declarations.numberOfArrows - 1].deleted = false;
                yield return wait;
            }
            yield return wait2;
        }
        else
        {
            WaitForSeconds wait = new WaitForSeconds(0.20f);
            WaitForSeconds wait2 = new WaitForSeconds(3f);
            for (int i = 0; i < 80; i++)
            {
                int typeOfArrow = (int)Math.Floor(UnityEngine.Random.Range(0f, 3.999999f));
                if (typeOfArrow == 0)
                {
                    generateLeft();
                }
                else if (typeOfArrow == 1)
                {
                    generateUp();
                }
                else if (typeOfArrow == 2)
                {
                    generateDown();
                }
                else
                {
                    generateRight();
                }
                declarations.arrowArray[declarations.numberOfArrows - 1].deleted = false;
                yield return wait;
            }
            yield return wait2;
        }
    }

    public void generateRight()
    {
        declarations.arrowArray[declarations.numberOfArrows] = new Arrow();
        declarations.arrowArray[declarations.numberOfArrows].type = 3;
        declarations.arrowArray[declarations.numberOfArrows].thisObj = Instantiate(declarations.arrows[3], new Vector2(908f, 1000f), Quaternion.identity, declarations.canvas.transform);
        declarations.numberOfArrows++;
    }
    public void generateDown()
    {
        declarations.arrowArray[declarations.numberOfArrows] = new Arrow();
        declarations.arrowArray[declarations.numberOfArrows].type = 2;
        declarations.arrowArray[declarations.numberOfArrows].thisObj = Instantiate(declarations.arrows[2], new Vector2(758f, 1000f), Quaternion.identity, declarations.canvas.transform);
        declarations.numberOfArrows++;
    }
    public void generateUp()
    {
        declarations.arrowArray[declarations.numberOfArrows] = new Arrow();
        declarations.arrowArray[declarations.numberOfArrows].type = 1;
        declarations.arrowArray[declarations.numberOfArrows].thisObj = Instantiate(declarations.arrows[1], new Vector2(608f, 1000f), Quaternion.identity, declarations.canvas.transform);
        declarations.numberOfArrows++;
    }
    public void generateLeft()
    {
        declarations.arrowArray[declarations.numberOfArrows] = new Arrow();
        declarations.arrowArray[declarations.numberOfArrows].type = 0;
        declarations.arrowArray[declarations.numberOfArrows].thisObj = Instantiate(declarations.arrows[0], new Vector2(458f, 1000f), Quaternion.identity, declarations.canvas.transform);
        declarations.numberOfArrows++;
    }
}
