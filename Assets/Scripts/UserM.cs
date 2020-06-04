using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserM {

    public int p_id { get; set; }
    public string p_name { get; set; }
    public int p_xp { get; set; }
    public float p_atk { get; set; }
    public float p_def { get; set; }
    public int p_cash { get; set; }
    public int p_played { get; set; }
    public int p_won { get; set; }
    public string p_email { get; set; }
    public int p_confemail { get; set; }
    public string p_token { get; set; }
    public int p_class { get; set; }
    public int p_eqw { get; set; }
    public int p_eqa { get; set; }
    public int p_eqm { get; set; }
    public string p_knownSkills { get; set; }
    public int[] p_knowSkillsArray = new int[15];
    public int p_item1 { get; set; }
    public int p_item2 { get; set; }
    public int p_item3 { get; set; }
    public int p_item4 { get; set; }
    public int p_item5 { get; set; }
    public int p_item6 { get; set; }
    public int p_item7 { get; set; }
    public int p_item8 { get; set; }
    public int p_item9 { get; set; }
    public int p_item10 { get; set; }
    public int p_item11 { get; set; }
    public int p_item12 { get; set; }

    public UserM()
    {
        p_id = 0;
        p_name = null;
        p_xp = 0;
        p_atk = 0f;
        p_def = 0f;
        p_cash = 0;
        p_played = 0;
        p_won = 0;
        p_email = null;
        p_confemail = 0;
        p_token = null;
        p_class = 0;
        p_eqw = 0;
        p_eqa = 0;
        p_eqm = 0;
        p_knownSkills = null;
        for (int i = 0; i < 15; i ++)
        {
            p_knowSkillsArray[i] = 0;
        }
        p_item1 = 0;
        p_item2 = 0;
        p_item3 = 0;
        p_item4 = 0;
        p_item5 = 0;
        p_item6 = 0;
        p_item7 = 0;
        p_item8 = 0;
        p_item9 = 0;
        p_item10 = 0;
        p_item11 = 0;
        p_item12 = 0;
    }

}