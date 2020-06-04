using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class 
{
    public int c_id { get; set; }
    public string c_name { get; set; }
    public int c_atk { get; set; }
    public int c_def { get; set; }
    public int c_hp { get; set; }
    public Sprite c_sprite { get; set; }
    public Sprite c_spriteHead { get; set; }
    public GameObject c_model { get; set; }

    public Class()
    {
        c_id = 0;
        c_name = "";
        c_atk = 0;
        c_def = 0;
        c_hp = 0;
        c_sprite = null;
        c_spriteHead = null;
        c_model = null;
    }
}
