using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialHandler : MonoBehaviour
{

    string[] tutorialTexts;
    
    void Start()
    {
        Camera.main.GetComponent<dataShowerMain>().setAll();
        tutorialTexts = new string[24]{
        "Hello, warrior! Welcome to Colosseum. Here, you will be able to fight in skill-based matches and prove that you are the best arrow-hitter around.",
        "Here is your home screen. You have two bars: up and down. On the upper side, you can change your settings and view your stats.",
        "The first stat is your attack value. This is a sum from your class attack value and your weapon attack value.",
        "Then, you have your defense. Your defense is calculated from your base class defense and your equipped armor.",
        "The third stat is your cash. Use your cash to buy items and skills that you can use in your future fights.",
        "The fourth stat is less important - your winrate. What percent of your games you are winning so far. N/A means not applicable, since you haven't played yet.",
        "On the bottom side, there are all the places you can be in. Now you're at home. This is the main place where you can see information about your character.",
        "The second option is the fighting option, but you will see more on that later.", // 7
        "Next up is the leaderboard. Here you can see the top players of Colosseum.", // 8
        "Your inventory is really precious. Even though you have limited space for items, you can store everything you need to succeed in battle.", // 9
        "The next place you can be in is the shop. There, you can buy weapons, armor, medallions and skill scrolls. The medallions are useful items which help in battle.",
        "Do you have a friend playing Colosseum? Search him up using the search button!", // 11
        "Next up is the spellbook. Here, you can view all the spells you know.", // 12
        "That hourglass is your match history. If you don't know how you ended up having a low winrate, here should be the first place to go.", // 13
        "The last button means logout. This means you will go back to the home screen. Please use the X in the upper right corner if you want to call it a day.",
        "Welcome to the inventory! Your items are on the right. On the left, you will see information about them.", // 14
        "Welcome to the shop, warrior! Equip yourself with legendary weapons and thrive to be the best! On the bottom side, you can see item categories: weapons, armors, medallions and skills.",
        "On the right, you can scroll through the pages of the shop.", // 16
        "This is a turn-based game. Please remember you are not playing against actual humans, but you're playing against their characters, just like they will be playing against yours.",
        "In each of your turns, you will be able to use either of these: the first move is a punch, which you can use everytime. You can see how much damage you can deal with that. It is calculated based on how much your class can deal.",
        "The second option is a weapon attack. The damage dealt is calculated based on your attack value.",
        "Finally, the third option is a skill attack. Each turn, a random skill of yours for that specific weapon will be picked. The damage is calculated based on the skills damage and your attack value.",
        "If the move deals a lot of damage, expect a flood of fast arrows. If the move is easy, expect a couple of easy to hit arrows.",
        "That is about all. Good luck!" };
        declarations.currentText.text = tutorialTexts[0];
        declarations.currentPageTutorial = 0;
    }

    public void nextPage()
    {
        if (declarations.currentPageTutorial == 14)
        {
            Camera.main.GetComponent<dataShowerMain>().inventoryPanel();
            Camera.main.GetComponent<showItem>().loadInventory();
        }
        if (declarations.currentPageTutorial == 15)
        {
            Camera.main.GetComponent<dataShowerMain>().shopPanel();
        }
        if (declarations.currentPageTutorial == 17)
        {
            Camera.main.GetComponent<dataShowerMain>().setAll();
        }
        if (declarations.currentPageTutorial == 23)
        {
            declarations.tutorial.SetActive(false);
        }
        declarations.currentPageTutorial++;
        if (declarations.currentPageTutorial < 24)
        {
            declarations.currentText.text = tutorialTexts[declarations.currentPageTutorial];
        } 
    }
    
}
