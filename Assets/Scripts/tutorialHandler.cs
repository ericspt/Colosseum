using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialHandler : MonoBehaviour
{

    string[] tutorialTexts;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("tutorial_completed") == 0)
        {
            Camera.main.GetComponent<dataShowerMain>().setAll();
            tutorialTexts = new string[11]{
                            "Hello, warrior! Welcome to Colosseum. Here, you will be able to fight in skill-based matches and prove that you are the best arrow-hitter around.",
                            "You're currently at home, where you can view information about your character.",
                            "Welcome to the inventory! Your items are on the right. On the left, you will see information about them.", // 14
                            "Welcome to the shop, warrior! Equip yourself with legendary weapons and thrive to be the best! On the bottom side, you can see item categories: weapons, armors, medallions and skills.",
                            "On the right, you can scroll through the pages of the shop.", // 16
                            "This is a turn-based game. Please remember you are not playing against actual humans, but you're playing against their characters, just like they will be playing against yours.",
                            "In each of your turns, you will be able to use either of these: the first move is a punch, which you can use everytime.",
                            "The second option is a weapon attack. The damage dealt is calculated based on your attack value.",
                            "The third option is a skill attack. Each turn, a random skill of yours for your weapon will be picked. The damage is calculated based on the skill damage and your attack value.",
                            "If the move deals a lot of damage, expect a flood of fast arrows. If the move is easy, expect a couple of easy to hit arrows.",
                            "That is about all. Good luck!"};
            declarations.currentText.text = tutorialTexts[0];
            declarations.currentPageTutorial = 0;
        }
        else
        {
            Camera.main.GetComponent<dataShowerMain>().setAll();
            declarations.tutorial.SetActive(false);
        }
    }

    public void nextPage()
    {
        if (declarations.currentPageTutorial == 1)
        {
            Camera.main.GetComponent<dataShowerMain>().inventoryPanel();
            Camera.main.GetComponent<showItem>().loadInventory();
        }
        if (declarations.currentPageTutorial == 2)
        {
            Camera.main.GetComponent<dataShowerMain>().shopPanel();
        }
        if (declarations.currentPageTutorial == 4)
        {
            Camera.main.GetComponent<dataShowerMain>().setAll();
        }
        if (declarations.currentPageTutorial == 10)
        {
            declarations.tutorial.SetActive(false);
            PlayerPrefs.SetInt("tutorial_completed", 1);
            PlayerPrefs.Save();
        }
        declarations.currentPageTutorial++;
        if (declarations.currentPageTutorial < 11)
        {
            declarations.currentText.text = tutorialTexts[declarations.currentPageTutorial];
        }
    }
}
