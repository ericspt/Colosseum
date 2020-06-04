using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public int i_id { get; set; }
    public string i_name { get; set; }
    public string i_description { get; set; }
    public int i_price { get; set; }
    public Sprite i_sprite { get; set; }
    public int i_lvlreq { get; set; }
    public int i_class { get; set; }
    public GameObject i_go { get; set; }
    public Skill[] i_skills { get; set; }
    public int i_skillsLength { get; set; }
    public bool i_equipability { get; set; }
    public bool i_usability { get; set; }
    public int i_type { get; set; }
    public int i_atk { get; set; }
    public int i_def { get; set; }

    public Item()
    {
        i_id = 0;
        i_name = null;
        i_description = null;
        i_price = 0;
        i_sprite = null;
        i_lvlreq = 0;
        i_class = 0;
        i_go = null;
        i_skillsLength = 0;
        i_equipability = false;
        i_usability = false;
        i_type = 0; // 1 = Weapon, 2 = Armor, 3 = Medallion, 4 = Skill Scroll, 
        i_atk = 0;
        i_def = 0;
    }

}