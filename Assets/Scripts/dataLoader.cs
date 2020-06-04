using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class dataLoader : MonoBehaviour {

    public string[] users;
    public string[] usersItems;
    public string[] matches;
    public static UserM[] usersM = new UserM[1000];
    public static int usersLength;

    public IEnumerator matchHistoryIE()
    {
        string MatchHistoryURL = "http://playcolosseum.com/getMatchHistory.php";
        UnityWebRequest wwwH = UnityWebRequest.Get(MatchHistoryURL);
        yield return wwwH.SendWebRequest();
        string matchHistoryString = Encoding.UTF8.GetString(wwwH.downloadHandler.data);
        declarations.playerHistorySize = 0;
        for (int i = 0; i < matchHistoryString.Length; i++)
        {
            if (matchHistoryString[i] == ';')
            {
                declarations.playerHistorySize++;
            }
        }
        matches = matchHistoryString.Split(';');
        for (int i = 0; i < declarations.playerHistorySize; i++)
        {
            if (matches[i] != null)
            {
                declarations.playerHistory[i] = new HistoryMatch();
                declarations.playerHistory[i].m_matchID = Int32.Parse(GetDataValue(matches[i], "m_matchID:"));
                declarations.playerHistory[i].m_player1ID = Int32.Parse(GetDataValue(matches[i], "m_player1ID:"));
                declarations.playerHistory[i].m_player2ID = Int32.Parse(GetDataValue(matches[i], "m_player2ID:"));
                declarations.playerHistory[i].m_won= Int32.Parse(GetDataValue(matches[i], "m_won:"));
                declarations.playerHistory[i].m_day = GetDataValue(matches[i], "m_day:");
            }
        }
    }

    public IEnumerator loadDataIE()
    {
        string UsersDataURL = "http://playcolosseum.com/userData.php";
        UnityWebRequest usersData = UnityWebRequest.Get(UsersDataURL);
        yield return usersData.SendWebRequest();
        string UsersItemsURL = "http://playcolosseum.com/userItems.php";
        UnityWebRequest wwwL = UnityWebRequest.Get(UsersItemsURL);
        yield return wwwL.SendWebRequest();
        string usersDataString = Encoding.UTF8.GetString(usersData.downloadHandler.data);
        string usersItemsDataString = Encoding.UTF8.GetString(wwwL.downloadHandler.data); 
        usersLength = 0;
        for (int i = 0; i < usersDataString.Length; i ++)
        {
            if (usersDataString[i] == ';')
            {
                usersLength++;
            }
        }
        users = usersDataString.Split(';');
        usersItems = usersItemsDataString.Split(';');
        for (int i = 0; i < usersLength; i++)
        {
            if (users[i] != null)
            {
                usersM[i] = new UserM();
                usersM[i].p_id = Int32.Parse(GetDataValue(users[i], "player_id:"));
                usersM[i].p_name = GetDataValue(users[i], "player_name:");
                usersM[i].p_xp = Int32.Parse(GetDataValue(users[i], "player_xp:"));
                usersM[i].p_atk = Int32.Parse(GetDataValue(users[i], "player_atk:"));
                usersM[i].p_def = Int32.Parse(GetDataValue(users[i], "player_def:"));
                usersM[i].p_cash = Int32.Parse(GetDataValue(users[i], "player_cash:"));
                usersM[i].p_played = Int32.Parse(GetDataValue(users[i], "player_played:"));
                usersM[i].p_won = Int32.Parse(GetDataValue(users[i], "player_won:"));
                usersM[i].p_email = GetDataValue(users[i], "player_email:");
                usersM[i].p_confemail = Int32.Parse(GetDataValue(users[i], "player_confemail:"));
                usersM[i].p_token = GetDataValue(users[i], "player_token:");
                usersM[i].p_class = Int32.Parse(GetDataValue(users[i], "player_class:"));
                usersM[i].p_eqw = Int32.Parse(GetDataValue(users[i], "player_eqw:"));
                usersM[i].p_eqa = Int32.Parse(GetDataValue(users[i], "player_eqa:"));
                usersM[i].p_eqm = Int32.Parse(GetDataValue(users[i], "player_eqm:"));
                usersM[i].p_knownSkills = GetDataValue(users[i], "player_knownSkills:");
                usersM[i].p_item1 = Int32.Parse(GetDataValue(usersItems[i], "item1:"));
                usersM[i].p_item2 = Int32.Parse(GetDataValue(usersItems[i], "item2:"));
                usersM[i].p_item3 = Int32.Parse(GetDataValue(usersItems[i], "item3:"));
                usersM[i].p_item4 = Int32.Parse(GetDataValue(usersItems[i], "item4:"));
                usersM[i].p_item5 = Int32.Parse(GetDataValue(usersItems[i], "item5:"));
                usersM[i].p_item6 = Int32.Parse(GetDataValue(usersItems[i], "item6:"));
                usersM[i].p_item7 = Int32.Parse(GetDataValue(usersItems[i], "item7:"));
                usersM[i].p_item8 = Int32.Parse(GetDataValue(usersItems[i], "item8:"));
                usersM[i].p_item9 = Int32.Parse(GetDataValue(usersItems[i], "item9:"));
                usersM[i].p_item10 = Int32.Parse(GetDataValue(usersItems[i], "item10:"));
                usersM[i].p_item11 = Int32.Parse(GetDataValue(usersItems[i], "item11:"));
                usersM[i].p_item12 = Int32.Parse(GetDataValue(usersItems[i], "item12:"));
            }
        }
    }
 
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    

}
