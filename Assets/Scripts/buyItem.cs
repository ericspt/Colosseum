using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyItem : MonoBehaviour {

    public static int lastItemSelectedId = 0;

    public void showItem (int id)
    {
        declarations.buyItemButton.SetActive(true);
        lastItemSelectedId = id;
        if (id == 0)
        {
            declarations.itemTitleBuy.text = "";
            declarations.itemDescriptionBuy.text = "";
            declarations.itemPrice.text = "";
            declarations.itemLvlReqBuy.text = "";
            declarations.itemClassesBuy.text = "";
            declarations.buyItemButton.SetActive(false);
        }
        else
        {
            Item theItem = declarations.items[id - 1];
            declarations.itemTitleBuy.text = theItem.i_name;
            declarations.itemDescriptionBuy.text = theItem.i_description;
            if (theItem.i_equipability == true)
            {
                declarations.itemDescriptionBuy.text += "\n";
                if (theItem.i_atk != 0)
                {
                    declarations.itemDescriptionBuy.text += "\nAttack: " + theItem.i_atk.ToString();
                }
                if (theItem.i_def != 0)
                {
                    declarations.itemDescriptionBuy.text += "\nDefense: " + theItem.i_def.ToString();
                }
            }
            else
            {
                Skill theSkill = declarations.skills[mapScrollIdToSkillId(theItem)];
                declarations.itemDescriptionBuy.text += "\n\n" + "Damage: " + theSkill.s_dmg;
                declarations.itemDescriptionBuy.text += "\nWeapon: " + declarations.items[theSkill.s_weapon].i_name;
                declarations.itemDescriptionBuy.text += "\nDifficulty: " + (theSkill.s_difficulty * 10).ToString();
            }
            declarations.itemPrice.text = "Price: " + declarations.items[id - 1].i_price.ToString();
            declarations.itemLvlReqBuy.text = "Level required: " + declarations.items[id - 1].i_lvlreq.ToString();
            declarations.itemClassesBuy.text = "Classes: " + classConvertToString(declarations.items[id - 1].i_class);
        }
    }

    private string classConvertToString(int classId)
    {
        if (classId == 1)
        {
            return "Soldier";
        }
        else if (classId == 2)
        {
            return "Mad Scientist";
        }
        else if (classId == 3)
        {
            return "Mage";
        }
        else if (classId == 4)
        {
            return "Ninja";
        }
        return "All";
    }

	public void buyTheItem ()
    {
        StartCoroutine(buyTheItemIE());
    }
    public IEnumerator buyTheItemIE()
    {
        if (checkOpenSlot() == 13)
        {
            declarations.errorPanel.SetActive(true);
            declarations.errorPanelText.text = "Your inventory is full!";
        }
        else if (declarations.playerLvl (login.currentUser.p_xp) < declarations.items [lastItemSelectedId - 1].i_lvlreq)
        {
            declarations.errorPanel.SetActive(true);
            declarations.errorPanelText.text = "You can't buy this item because your level is too small!";
        }
        else if (declarations.items [lastItemSelectedId - 1].i_class != 0 && declarations.items[lastItemSelectedId - 1].i_class != login.currentUser.p_class)
        {
            declarations.errorPanel.SetActive(true);
            declarations.errorPanelText.text = "You can't buy this item because it was not designed for your class!";
        }
        else
        {
            if (login.currentUser.p_cash >= declarations.items[lastItemSelectedId - 1].i_price)
            {
                login.currentUser.p_cash -= declarations.items[lastItemSelectedId - 1].i_price;
                putInOpenSlot(lastItemSelectedId);
                yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
                declarations.buyItemPanel.SetActive(false);
            }
            else
            {
                declarations.errorPanel.SetActive(true);
                declarations.errorPanelText.text = "You can't buy this item because you don't have enough funds.";
            }
        }
    }

    private int checkOpenSlot ()
    {
        if (login.currentUser.p_item1 == 0)
        {
            return 1;
        }
        else if (login.currentUser.p_item2 == 0)
        {
            return 2;
        }
        else if (login.currentUser.p_item3 == 0)
        {
            return 3;
        }
        else if (login.currentUser.p_item4 == 0)
        {
            return 4;
        }
        else if (login.currentUser.p_item5 == 0)
        {
            return 5;
        }
        else if (login.currentUser.p_item6 == 0)
        {
            return 6;
        }
        else if (login.currentUser.p_item7 == 0)
        {
            return 7;
        }
        else if (login.currentUser.p_item8 == 0)
        {
            return 8;
        }
        else if (login.currentUser.p_item9 == 0)
        {
            return 9;
        }
        else if (login.currentUser.p_item10 == 0)
        {
            return 10;
        }
        else if (login.currentUser.p_item11 == 0)
        {
            return 11;
        }
        else if (login.currentUser.p_item12 == 0)
        {
            return 12;
        }
        else
        {
            return 13;
        }
    }
    private void putInOpenSlot(int itemId)
    {
        int x = checkOpenSlot(); // First Free Slot
        if (x == 1)
        {
            login.currentUser.p_item1 = itemId;
        }
        else if (x == 2)
        {
            login.currentUser.p_item2 = itemId;
        }
        else if (x == 3)
        {
            login.currentUser.p_item3 = itemId;
        }
        else if (x == 4)
        {
            login.currentUser.p_item4 = itemId;
        }
        else if (x == 5)
        {
            login.currentUser.p_item5 = itemId;
        }
        else if (x == 6)
        {
            login.currentUser.p_item6 = itemId;
        }
        else if (x == 7)
        {
            login.currentUser.p_item7 = itemId;
        }
        else if (x == 8)
        {
            login.currentUser.p_item8 = itemId;
        }
        else if (x == 9)
        {
            login.currentUser.p_item9 = itemId;
        }
        else if (x == 10)
        {
            login.currentUser.p_item10 = itemId;
        }
        else if (x == 11)
        {
            login.currentUser.p_item11 = itemId;
        }
        else
        {
            login.currentUser.p_item12 = itemId;
        }
    }

    public static int mapScrollIdToSkillId(Item scroll)
    {
        string tmp = scroll.i_name.Substring(0, scroll.i_name.Length - 7);
        for (int i = 0; i < declarations.skillsLength; i++)
        {
            if (tmp == declarations.skills[i].s_name)
            {
                return i;
            }
        }
        // Pointless. 
        return scroll.i_id;
    }
}
