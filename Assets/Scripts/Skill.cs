using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public int s_id { get; set; }
    public string s_name { get; set; }
    public string s_description { get; set; }
    public int s_dmg { get; set; }
    public int s_weapon { get; set; }
    public float s_difficulty { get; set; }

    public Skill()
    {
        s_id = 0;
        s_name = null;
        s_description = null;
        s_dmg = 0;
        s_weapon = 0;
        s_difficulty = 1f;
    }
}
