using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class spellbook : MonoBehaviour
{
    public void unlearnSpell()
    {
        StartCoroutine(unlearnSpellIE());
    }
    public IEnumerator unlearnSpellIE ()
    {
        StringBuilder sb = new StringBuilder(login.currentUser.p_knownSkills);
        sb[login.currentUser.p_knowSkillsArray[declarations.lastSkillSelected]] = '0';
        login.currentUser.p_knownSkills = sb.ToString();
        declarations.spellSlots[declarations.lastSkillSelected].GetComponent<Image>().color = new Color(0.505f, 0.364f, 0.207f);
        declarations.spellSlots[declarations.lastSkillSelected].GetComponent<Image>().sprite = null;
        declarations.spellTitle.text = "";
        declarations.spellDescription.text = "";
        declarations.spellUnlearnButton.SetActive(false);
        print(login.currentUser.p_knowSkillsArray[0]);
        yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        spellbookIE();
        print(login.currentUser.p_knowSkillsArray[0]);
    }

    public void spellbookIE()
    {
        declarations.z = 0;
        for (int i = 0; i < 15; i ++)
        {
            declarations.spellSlots[i].GetComponent<Image>().sprite = null;
            declarations.spellSlots[i].GetComponent<Image>().color = new Color(0.505f, 0.364f, 0.207f);
        }
        for (int i = 0; i < declarations.skillsLength; i ++)
        {
            if (login.currentUser.p_knownSkills[i] == '1')
            {
                declarations.spellSlots[declarations.z].GetComponent<Image>().sprite = null;
                declarations.spellSlots[declarations.z].GetComponent<Image>().sprite = declarations.items[9].i_sprite;
                declarations.spellSlots[declarations.z].GetComponent<Image>().color = Color.white;
                login.currentUser.p_knowSkillsArray[declarations.z] = i;
                declarations.z++;
            }
        }
    }
    public void displaySkillInfo (int slot)
    {
        declarations.lastSkillSelected = slot;
        if (declarations.z <= slot)
        {
            declarations.spellTitle.text = "";
            declarations.spellDescription.text = "";
            declarations.spellUnlearnButton.SetActive(false);
        }
        else
        {
            declarations.spellUnlearnButton.SetActive(true);
            Skill theSkill = declarations.skills[login.currentUser.p_knowSkillsArray[slot]];
            declarations.spellTitle.text = theSkill.s_name;
            declarations.spellDescription.text = theSkill.s_description;
            declarations.spellDescription.text += "\n\n";
            declarations.spellDescription.text += "Damage: " + theSkill.s_dmg.ToString();
            declarations.spellDescription.text += "\nWeapon: " + declarations.items[theSkill.s_weapon - 1].i_name;
            declarations.spellDescription.text += "\nDifficulty: " + (theSkill.s_difficulty * 10).ToString();
        }
    }
}
