using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class dataShowerMain : MonoBehaviour {
   
    public void deactiveAllPanels ()
    {
        for (int i = 0; i < declarations.panelsLength; i++)
        {
            declarations.panels[i].SetActive(false);
        }
        matchHistory.destroyMatches();
    }

    public void fightPanel ()
    {
        deactiveAllPanels();
        StartCoroutine(setAllIE());
        declarations.panels[1].SetActive(true);
    }

    public void inventoryPanel()
    {
        deactiveAllPanels();
        declarations.panels[4].SetActive(true);
        StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE());
    }

    public void shopPanel()
    {
        deactiveAllPanels();
        StartCoroutine(setAllIE());
        declarations.panels[5].SetActive(true);
    }

    public void quitApp ()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
              Application.Quit();
        #endif
    }

    public void setAll ()
    {
        deactiveAllPanels();
        declarations.panels[0].SetActive(true);
        StartCoroutine(setAllIE());
    }
    public IEnumerator setAllIE()
    {
        declarations.loadingPanel.SetActive(true);
        yield return StartCoroutine(Camera.main.GetComponent<dataLoader>().loadDataIE());
        login.currentUser = dataLoader.usersM[login.currentUser.p_id - 1]; // dupa asta se face din 19 -> 22
        declarations.attackUpdate();
        declarations.defenseUpdate();
        declarations.currentPlayerAttack.text = login.currentUser.p_atk.ToString();
        declarations.currentPlayerDef.text = login.currentUser.p_def.ToString();
        declarations.currentPlayerCash.text = login.currentUser.p_cash.ToString();
        #region Winrate calculation
        if (login.currentUser.p_played != 0)
        {
            declarations.currentPlayerWR.text = ((100 * login.currentUser.p_won) / login.currentUser.p_played).ToString() + "%";
        }
        else
        {
            declarations.currentPlayerWR.text = "N/A";
        }
        #endregion
        declarations.currentPlayerName.text = login.currentUser.p_name.ToString();
        #region Class display
        declarations.currentPlayerClassButton.GetComponent<Image>().sprite = declarations.classes[login.currentUser.p_class - 1].c_sprite;
        #endregion
        #region Equipment display
        if (login.currentUser.p_eqw != 0)
        {
            declarations.currentPlayerWeaponButton.GetComponent<Image>().color = Color.white;
            declarations.currentPlayerWeaponButton.GetComponent<Image>().sprite = declarations.items[login.currentUser.p_eqw - 1].i_sprite;
        }
        if (login.currentUser.p_eqa != 0)
        {
            declarations.currentPlayerArmorButton.GetComponent<Image>().color = Color.white;
            declarations.currentPlayerArmorButton.GetComponent<Image>().sprite = declarations.items[login.currentUser.p_eqa - 1].i_sprite;
        }
        if (login.currentUser.p_eqm != 0)
        {
            declarations.currentPlayerMedallionButton.GetComponent<Image>().color = Color.white;
            declarations.currentPlayerMedallionButton.GetComponent<Image>().sprite = declarations.items[login.currentUser.p_eqm - 1].i_sprite;
        }
        #endregion
        declarations.currentPlayerLvl.text = "Level " + declarations.playerLvl(login.currentUser.p_xp).ToString();
        declarations.currentPlayerXP.text = login.currentUser.p_xp.ToString() + "/" + declarations.maxXP[declarations.playerLvl(login.currentUser.p_xp)] + " XP";
        #region Sound
        AudioSource audioSource;
        audioSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        declarations.audioSliderMusicVolume.value = audioSource.volume;
        #endregion
        declarations.loadingPanel.SetActive(false);
    }

    public void searchUser ()
    {
        deactiveAllPanels();
        StartCoroutine(searchUserIE());
    }
    public IEnumerator searchUserIE()
    {
        yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        makeSearchVisible();
    }

    public void setUserProfile()
    {
        deactiveAllPanels();
        declarations.panels[6].SetActive(true);
        declarations.panels[7].SetActive(true);
        declarations.searchButton.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        declarations.searchInputField.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        StartCoroutine(preSetUserProfileIE());
    }
    public IEnumerator preSetUserProfileIE()
    {
        yield return (StartCoroutine(setUserProfileIE()));
        declarations.panels[7].SetActive(false);
    }
    public IEnumerator setUserProfileIE()
    {
        declarations.loadingPanel.SetActive(true);
        yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        int id = declarations.nameToId (declarations.searchPlayerName.text);
        if (id != -1)
        {
            UserM theUser = dataLoader.usersM[id - 1];
            declarations.attackUpdateId(theUser.p_id);
            declarations.defenseUpdateId(theUser.p_id);
            declarations.searchedPlayerAttack.text = theUser.p_atk.ToString();
            declarations.searchedPlayerDef.text = theUser.p_def.ToString();
            declarations.searchedPlayerCash.text = theUser.p_cash.ToString();
            #region Winrate calculation
            if (theUser.p_played != 0)
            {
                declarations.searchedPlayerWR.text = ((100 * theUser.p_won) / theUser.p_played).ToString() + "%";
            }
            else
            {
                declarations.searchedPlayerWR.text = "N/A";
            }
            #endregion
            declarations.searchedPlayerName.text = theUser.p_name.ToString();
            #region Class display
            declarations.searchedPlayerClassButton.GetComponent<Image>().sprite = declarations.classes[theUser.p_class - 1].c_sprite;
            #endregion
            #region Equipment display
            if (theUser.p_eqw != 0)
            {
                declarations.searchedPlayerWeaponButton.GetComponent<Image>().color = Color.white;
                declarations.searchedPlayerWeaponButton.GetComponent<Image>().sprite = declarations.items[theUser.p_eqw - 1].i_sprite;
            }
            else
            {
                declarations.searchedPlayerWeaponButton.GetComponent<Image>().sprite = declarations.currentPlayerDefaultIcons[0];
            }
            if (theUser.p_eqa != 0)
            {
                declarations.searchedPlayerArmorButton.GetComponent<Image>().color = Color.white;
                declarations.searchedPlayerArmorButton.GetComponent<Image>().sprite = declarations.items[theUser.p_eqa - 1].i_sprite;
            }
            else
            {
                declarations.searchedPlayerArmorButton.GetComponent<Image>().sprite = declarations.currentPlayerDefaultIcons[1];
            }
            if (theUser.p_eqm != 0)
            {
                declarations.searchedPlayerMedallionButton.GetComponent<Image>().color = Color.white;
                declarations.searchedPlayerMedallionButton.GetComponent<Image>().sprite = declarations.items[theUser.p_eqm - 1].i_sprite;
            }
            else
            {
                declarations.searchedPlayerMedallionButton.GetComponent<Image>().sprite = declarations.currentPlayerDefaultIcons[2];
            }
            #endregion
            declarations.searchedPlayerLvl.text = "Level " + declarations.playerLvl(theUser.p_xp).ToString();
            declarations.searchedPlayerXP.text = theUser.p_xp.ToString() + "/" + declarations.maxXP[declarations.playerLvl(theUser.p_xp)] + " XP";
        }
        else
        {
            declarations.errorPanel.SetActive(true);
            declarations.errorPanelText.text = "A player with that name doesn't exist. Yikes.";
            deactiveAllPanels();
            makeSearchVisible();
        }
        declarations.loadingPanel.SetActive(false);
    }
    
    public void leaderboard()
    {
        deactiveAllPanels();
        declarations.panels[3].SetActive(true);
        StartCoroutine(leaderboardIE());
    }
    public IEnumerator leaderboardIE()
    {
        yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        fight.updateUsersLvlArray();
        for (int i = 0; i < 5; i++)
        {
            declarations.namesLeaderboard[i].text = fight.usersS[i].p_name;
            declarations.xpLeaderboard[i].text = fight.usersS[i].p_xp.ToString();
        }
    }

    public void spellbook()
    {
        deactiveAllPanels();
        declarations.panels[8].SetActive(true);
        StartCoroutine(spellbookIE());
    }
    public IEnumerator spellbookIE()
    {
        yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        Camera.main.GetComponent<spellbook>().spellbookIE();
    }

    public void showMatchHistory()
    {
        deactiveAllPanels();
        declarations.panels[9].SetActive(true);
        StartCoroutine(matchHistoryIE());
    }
    public IEnumerator matchHistoryIE()
    {
        yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        yield return (StartCoroutine(Camera.main.GetComponent<matchHistory>().GetMatchHistory()));
    }

    public void makeSearchVisible()
    {
        declarations.searchButton.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        declarations.searchInputField.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        declarations.panels[7].SetActive(true);
    }
}
