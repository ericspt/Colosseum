using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class showItem : MonoBehaviour {

    public static int lastItemSelected;

    public void loadInventory()
    {
        for (int i = 1; i <= 12;i ++)
        {
            showTheItem(i);
        }
        declarations.itemTitle.text = "";
        declarations.itemDescription.text = "";
        declarations.itemEquipped.text = "";
        declarations.useItemButton.SetActive(false);
        declarations.sellItemButton.SetActive(false);
    }

    private void makeTheButtonGo (int id)
    {
        declarations.itemTitle.text = "";
        declarations.itemDescription.text = "";
        declarations.itemEquipped.text = "";
        declarations.useItemButton.SetActive(false);
        declarations.sellItemButton.SetActive(false);
        declarations.buttonsTBR[id - 1].GetComponent<Image>().sprite = null;
        declarations.buttonsTBR[id - 1].GetComponent<Image>().color = new Color(0.505f, 0.364f, 0.207f);
        lastItemSelected = 0;
    }

    public void showTheItem (int id)
    {
        if (idConversion(id) == 0)
        {
            makeTheButtonGo(id);
        }
        else
        {
            declarations.buttonsTBR[id - 1].GetComponent<Image>().sprite = null;
            declarations.buttonsTBR[id - 1].GetComponent<Image>().sprite = declarations.items[idConversion(id) - 1].i_sprite;
            declarations.buttonsTBR[id - 1].GetComponent<Image>().color = Color.white;
            lastItemSelected = idConversion(id);
            Item theItem = declarations.items[lastItemSelected - 1];
            declarations.sellItemButton.SetActive(true);
            declarations.itemTitle.text = theItem.i_name;
            declarations.itemDescription.text = theItem.i_description;
            if (theItem.i_type == 4)
            {
                Skill theSkill = declarations.skills[mapScrollIdToSkillId(theItem)];
                declarations.itemDescription.text += "\n\nDamage: " + theSkill.s_dmg;
                declarations.itemDescription.text += "\nWeapon: " + declarations.items[theSkill.s_weapon].i_name;
                declarations.itemDescription.text += "\nDifficulty: " + (theSkill.s_difficulty * 10).ToString();
                print(theSkill.s_name);
            }
            declarations.useItemButton.SetActive(false);
            if (theItem.i_usability == true)
            {
                declarations.useItemButton.SetActive(true);
                declarations.useItemText.text = "Use";
                declarations.itemEquipped.text = "";
            }
            else if (theItem.i_equipability == true)
            {
                declarations.itemDescription.text += "\n";
                if (theItem.i_atk != 0)
                {
                    declarations.itemDescription.text += "\nAttack: " + theItem.i_atk.ToString();
                }
                if (theItem.i_def != 0)
                {
                    declarations.itemDescription.text += "\nDefense: " + theItem.i_def.ToString();
                }
                declarations.useItemButton.SetActive(true);
                if ((theItem.i_type == 1 && login.currentUser.p_eqw == 0) || (theItem.i_type == 2 && login.currentUser.p_eqa == 0) || (theItem.i_type == 3 && login.currentUser.p_eqm == 0))
                {
                    declarations.useItemText.text = "Equip";
                    declarations.itemEquipped.text = "Status: Not Equipped";
                }
                else if ((theItem.i_type == 1 && login.currentUser.p_eqw == theItem.i_id) || (theItem.i_type == 2 && login.currentUser.p_eqa == theItem.i_id) || (theItem.i_type == 3 && login.currentUser.p_eqm == theItem.i_id))
                {
                    declarations.useItemText.text = "Unequip";
                    declarations.itemEquipped.text = "Status: Equipped";
                }
                else
                {
                    declarations.useItemText.text = "Equip";
                    declarations.itemEquipped.text = "Status: Not Equipped";
                }
            }
        }
    }

    public void useTheItem ()
    {
        StartCoroutine(useItem());
    }
    public IEnumerator useItem()
    {
        declarations.loadingPanel.SetActive(true);
        Item theItem = declarations.items[lastItemSelected - 1];
        // Equip
        if (theItem.i_equipability == true)
        {
            if (declarations.useItemText.text == "Equip")
            {
                if ((theItem.i_type == 1 && login.currentUser.p_eqw != 0) || (theItem.i_type == 2 && login.currentUser.p_eqa != 0) || (theItem.i_type == 3 && login.currentUser.p_eqm != 0))
                {
                    declarations.errorPanel.SetActive(true);
                    declarations.errorPanelText.text = "An item of this type is already equipped!";
                }
                // Actually equip the item
                else if ((theItem.i_type == 1 && login.currentUser.p_eqw == 0) || (theItem.i_type == 2 && login.currentUser.p_eqa == 0) || (theItem.i_type == 3 && login.currentUser.p_eqm == 0))
                {
                    declarations.itemEquipped.text = "Status: Equipped";
                    declarations.useItemText.text = "Unequip";
                    equipItem(theItem);
                }
            }
            else
            {
                declarations.itemEquipped.text = "Status: Not Equipped";
                declarations.useItemText.text = "Equip";
                equipItem(new Item());
            }
        }
        else
        {
            if (theItem.i_type == 4)
            {
                StringBuilder sb = new StringBuilder (login.currentUser.p_knownSkills);
                sb[mapScrollIdToSkillId(theItem)] = '1';
                login.currentUser.p_knownSkills = sb.ToString();
            }

            yield return (StartCoroutine(deleteItem(lastItemSelected)));
        }
        yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
        declarations.loadingPanel.SetActive(false);
        declarations.useItemPanel.SetActive(false);
    }

    public static int mapScrollIdToSkillId (Item scroll)
    {
        string tmp = scroll.i_name.Substring(0, scroll.i_name.Length - 7);
        for (int i = 0; i < declarations.skillsLength; i ++)
        {
            if (tmp == declarations.skills[i].s_name)
            {
                return i;
            }
        }
        // Pointless. 
        return scroll.i_id;
    }

    public void updateItemPriceSellPanel()
    {
        declarations.sellItemTextPanel.text = "Are you sure you want to sell this item for " + (declarations.items[lastItemSelected - 1].i_price / 2).ToString() + " coins?";
    }
    public void sellTheItem()
    {
        StartCoroutine(sellItem());
    }
    public IEnumerator sellItem()
    {
        declarations.loadingPanel.SetActive(true);
        login.currentUser.p_cash += declarations.items[lastItemSelected - 1].i_price / 2;
        equipItem(new Item());
        yield return (StartCoroutine(deleteItem(lastItemSelected)));
        declarations.loadingPanel.SetActive(false);
        declarations.sellItemPanel.SetActive(false);
    }

    private void equipItem (Item item)
    {
        Item theItem = declarations.items[lastItemSelected - 1];

        if (theItem.i_type == 1)
        {
            login.currentUser.p_eqw = item.i_id;
            //declarations.currentPlayerWeaponButton.GetComponent<Image>().sprite = theItem.i_sprite;
            if (item.i_id != 0)
            {
                declarations.currentPlayerWeaponButton.GetComponent<Image>().sprite = item.i_sprite;
            }
            else
            {
                declarations.currentPlayerWeaponButton.GetComponent<Image>().sprite = declarations.currentPlayerDefaultIcons[0];
            }
        }
        else if (theItem.i_type == 2)
        {
            login.currentUser.p_eqa = item.i_id;
            //declarations.currentPlayerArmorButton.GetComponent<Image>().sprite = theItem.i_sprite;
            if (item.i_id != 0)
            {
                declarations.currentPlayerArmorButton.GetComponent<Image>().sprite = item.i_sprite;
            }
            else
            {
                declarations.currentPlayerArmorButton.GetComponent<Image>().sprite = declarations.currentPlayerDefaultIcons[1];
            }
        }
        else if (theItem.i_type == 3)
        {
            login.currentUser.p_eqm = item.i_id;
            //declarations.currentPlayerMedallionButton.GetComponent<Image>().sprite = theItem.i_sprite;
            if (item.i_id != 0)
            {
                declarations.currentPlayerMedallionButton.GetComponent<Image>().sprite = item.i_sprite;
            }
            else
            {
                declarations.currentPlayerMedallionButton.GetComponent<Image>().sprite = declarations.currentPlayerDefaultIcons[2];
            }
        }
    }

    private IEnumerator deleteItem (int lastItemSelected)
    {
        for (int i = 1; i <= 12; i++)
        {
            if (idConversion(i) == lastItemSelected)
            {
                itemDeletion(i);
                yield return (StartCoroutine(Camera.main.GetComponent<declarations>().uploadAndSetDataIE()));
                makeTheButtonGo(i);
                break;
            }
        }
    }

    private int idConversion (int id)
    {
        if (id == 1)
        {
            return login.currentUser.p_item1;
        }
        else if (id == 2)
        {
            return login.currentUser.p_item2;
        }
        else if (id == 3)
        {
            return login.currentUser.p_item3;
        }
        else if (id == 4)
        {
            return login.currentUser.p_item4;
        }
        else if (id == 5)
        {
            return login.currentUser.p_item5;
        }
        else if (id == 6)
        {
            return login.currentUser.p_item6;
        }
        else if (id == 7)
        {
            return login.currentUser.p_item7;
        }
        else if (id == 8)
        {
            return login.currentUser.p_item8;
        }
        else if (id == 9)
        {
            return login.currentUser.p_item9;
        }
        else if (id == 10)
        {
            return login.currentUser.p_item10;
        }
        else if (id == 11)
        {
            return login.currentUser.p_item11;
        }
        else
        {
            return login.currentUser.p_item12;
        }
    }
    private void itemDeletion(int id)
    {
        if (id == 1)
        {
            login.currentUser.p_item1 = 0;
        }
        else if (id == 2)
        {
            login.currentUser.p_item2 = 0;
        }
        else if (id == 3)
        {
            login.currentUser.p_item3 = 0;
        }
        else if (id == 4)
        {
            login.currentUser.p_item4 = 0;
        }
        else if (id == 5)
        {
            login.currentUser.p_item5 = 0;
        }
        else if (id == 6)
        {
            login.currentUser.p_item6 = 0;
        }
        else if (id == 7)
        {
            login.currentUser.p_item7 = 0;
        }
        else if (id == 8)
        {
            login.currentUser.p_item8 = 0;
        }
        else if (id == 9)
        {
            login.currentUser.p_item9 = 0;
        }
        else if (id == 10)
        {
            login.currentUser.p_item10 = 0;
        }
        else if (id == 11)
        {
            login.currentUser.p_item11 = 0;
        }
        else
        {
            login.currentUser.p_item12 = 0;
        }
    }
}
