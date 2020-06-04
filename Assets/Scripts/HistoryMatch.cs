using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryMatch
{
    public int m_matchID { get; set; }
    public int m_player1ID { get; set; }
    public int m_player2ID { get; set; }
    public int m_won { get; set; }
    public string m_day { get; set; }

    public HistoryMatch()
    {
        m_matchID = 0;
        m_player1ID = 0;
        m_player2ID = 0;
        m_won = 0;
        m_day = null;
    }
}
