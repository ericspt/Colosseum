using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;
using UnityEngine.Networking;
using System;

public class matchHistory : MonoBehaviour
{

    public GameObject matchPrefab;

    public static int matchID;
    public static int player1ID;
    public static int player2ID;
    public static int won;
	public static string day;
    
    public static int currentPlayerMatches = 0;

    public static int currentPage = 1;

    public static GameObject[] matches = new GameObject[3];
    public static GameObject matchUp;
    public static GameObject matchMiddle;
    public static GameObject matchBottom;

    string UploadGameURL = "http://playcolosseum.com/uploadGame.php";
    string UpdateWonGameURL = "http://playcolosseum.com/updateWonGame.php";

    public IEnumerator UploadGame()
    {
        WWWForm form = new WWWForm();
        form.AddField("matchIDPost", matchID);
        form.AddField("player1IDPost", player1ID);
        form.AddField("player2IDPost", player2ID);
        form.AddField("wonPost", won);
        form.AddField("dayPost", day.ToString());
        UnityWebRequest www = UnityWebRequest.Post(UploadGameURL, form);
        yield return www.SendWebRequest();
        
    }

    public IEnumerator UpdateWonGame()
    {
        declarations.loadingPanel.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("matchIDPost", matchID);
        form.AddField("player1IDPost", player1ID);
        UnityWebRequest www = UnityWebRequest.Post(UpdateWonGameURL, form);
        yield return www.SendWebRequest();
    }

    public IEnumerator GetMatchHistory()
    {
        yield return StartCoroutine(Camera.main.GetComponent<dataLoader>().matchHistoryIE());
        currentPlayerMatches = 0;
        for (int i = 0; i < declarations.playerHistorySize; i ++)
        {
            if (declarations.playerHistory[i].m_player1ID == login.currentUser.p_id)
            {
                declarations.currentPlayerHistory[currentPlayerMatches++] = declarations.playerHistory[i];
            }
        }
        spawnHistory();
    }

    public void spawnHistory()
    {
        if (currentPage <= currentPlayerMatches)
        {
            matches[0] = Instantiate(matchPrefab, new Vector3(583.0f, 564.0f, 0f), Quaternion.identity, declarations.matchHistoryGO.transform) as GameObject;
            fill(matches[0], 0);
        }
        if (currentPage + 1 <= currentPlayerMatches)
        {
            matches[1] = Instantiate(matchPrefab, new Vector3(583.0f, 400f, 0f), Quaternion.identity, declarations.matchHistoryGO.transform) as GameObject;
            fill(matches[1], 1);
        }
        if (currentPage + 2 <= currentPlayerMatches)
        {
            matches[2] = Instantiate(matchPrefab, new Vector3(583.0f, 236.0f, 0f), Quaternion.identity, declarations.matchHistoryGO.transform) as GameObject;
            fill(matches[2], 2);
        }
    }

    public void movePageUp()
    {
        if (currentPage + 3 <= currentPlayerMatches)
        {
            currentPage += 3;
            destroyMatches();
            spawnHistory();
        }
    }
    public void movePageDown()
    {
        if (currentPage >= 4)
        {
            currentPage -= 3;
            destroyMatches();
            spawnHistory();
        }
    }

    public void fill(GameObject matchUp, int page)
    {
        int id1 = declarations.currentPlayerHistory[currentPage - 1 + page].m_player1ID - 1;
        int id2 = declarations.currentPlayerHistory[currentPage - 1 + page].m_player2ID - 1;
        int won = declarations.currentPlayerHistory[currentPage - 1 + page].m_won;
        string day = declarations.currentPlayerHistory[currentPage - 1 + page].m_day;
        if (won == 1)
        {
            matchUp.transform.GetChild(4).GetComponent<Text>().text = "WIN";
            matchUp.transform.GetChild(4).GetComponent<Text>().color = new Color(50f / 255f, 205f / 255f, 50f / 255f);
        }
        else
        {
            matchUp.transform.GetChild(4).GetComponent<Text>().text = "LOSE";
            matchUp.transform.GetChild(4).GetComponent<Text>().color = Color.red;
        }
        matchUp.transform.GetChild(0).GetComponent<Image>().sprite = declarations.classes[dataLoader.usersM[id1].p_class - 1].c_spriteHead;
        matchUp.transform.GetChild(1).GetComponent<Text>().text = dataLoader.usersM[id1].p_name;
        matchUp.transform.GetChild(2).GetComponent<Image>().sprite = declarations.classes[dataLoader.usersM[id2].p_class - 1].c_spriteHead;
        matchUp.transform.GetChild(3).GetComponent<Text>().text = dataLoader.usersM[id2].p_name;
        matchUp.transform.GetChild(5).GetComponent<Text>().text = day;
    }

    public static void destroyMatches()
    {
        for (int i = 0; i < 3; i++)
        {
            Destroy(matches[i]);
        }
    }
}
