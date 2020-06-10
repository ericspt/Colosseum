using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class declarations : MonoBehaviour {

    #region Main Menu
    public static GameObject loginPanel;
    public static GameObject registerPanel;
    public static Toggle toggle;
    public static InputField usernameTextLogin;
    public static InputField passwordTextLogin;
    public static GameObject confEmailPanel;
    public static GameObject classPanel;
    public static InputField usernameTextRegister;
    public static InputField passwordTextRegister;
    public static InputField emailTextRegister;
    public GameObject loginPanelNS;
    public GameObject registerPanelNS;
    public Toggle toggleNS;
    public InputField usernameTextLoginNS;
    public InputField passwordTextLoginNS;
    public GameObject confEmailPanelNS;
    public GameObject classPanelNS;
    public InputField usernameTextRegisterNS;
    public InputField passwordTextRegisterNS;
    public InputField emailTextRegisterNS;
    #endregion
    #region Version
    public static string version = "1.0.3";
    public static GameObject updatePanel;
    public GameObject updatePanelNS;
    #endregion
    #region Misc
    public static Canvas canvas;
    public static GameObject errorPanel;
    public static Text errorPanelText;
    public static GameObject wonPanel;
    public static GameObject lostPanel;
    public static GameObject loadingPanel;
    public static GameObject successPanel;
    public static Text successPanelText;
    public static float audioSliderMusicValue;
    public static Slider audioSliderMusicVolume;
    public static GameObject infoHover;
    public Canvas canvasNS;
    public GameObject errorPanelNS;
    public Text errorPanelTextNS;
    public GameObject wonPanelNS;
    public GameObject lostPanelNS;
    public GameObject loadingPanelNS;
    public GameObject successPanelNS;
    public Text successPanelTextNS;
    public Slider audioSliderMusicVolumeNS;
    public GameObject infoHoverNS;
    #endregion
    #region Player Stats
    public static Text currentPlayerAttack;
    public static Text currentPlayerDef;
    public static Text currentPlayerCash;
    public static Text currentPlayerWR;
    public static Text currentPlayerName;
    public static Text currentPlayerXP;
    public static Text currentPlayerLvl;
    public static Button currentPlayerClassButton;
    public static Button currentPlayerWeaponButton;
    public static Button currentPlayerArmorButton;
    public static Button currentPlayerMedallionButton;
    public static Sprite[] currentPlayerDefaultIcons = new Sprite[3];
    public Text currentPlayerAttackNS;
    public Text currentPlayerDefNS;
    public Text currentPlayerCashNS;
    public Text currentPlayerWRNS;
    public Text currentPlayerNameNS;
    public Text currentPlayerXPNS;
    public Text currentPlayerLvlNS;
    public Button currentPlayerClassButtonNS;
    public Button currentPlayerWeaponButtonNS;
    public Button currentPlayerArmorButtonNS;
    public Button currentPlayerMedallionButtonNS;
    public Sprite[] currentPlayerDefaultIconsNS = new Sprite[3];
    #endregion
    #region Item Shop
    public static GameObject confirmBuyItemButton;
    public static GameObject buyItemButton;
    public static GameObject buyItemPanel;
    public static Text itemTitleBuy;
    public static Text itemDescriptionBuy;
    public static Text itemPrice;
    public static Text itemLvlReqBuy;
    public static Text itemClassesBuy;
    public GameObject confirmBuyItemButtonNS;
    public GameObject buyItemButtonNS;
    public GameObject buyItemPanelNS;
    public Text itemTitleBuyNS;
    public Text itemDescriptionBuyNS;
    public Text itemPriceNS;
    public Text itemLvlReqBuyNS;
    public Text itemClassesBuyNS;
    #endregion
    #region Item inventory
    public static GameObject confirmUseItemButton;
    public static GameObject useItemButton;
    public static Text useItemText; // Use or Equip
    public static GameObject useItemPanel;
    public static Text useItemPanelText;
    public static GameObject confirmSellItemButton;
    public static GameObject sellItemButton;
    public static GameObject sellItemPanel;
    public static Text sellItemTextPanel;
    public static Text itemTitle;
    public static Text itemDescription;
    public static Text itemEquipped; // Status: Equipped or Not Equipped
    public GameObject confirmUseItemButtonNS;
    public GameObject useItemButtonNS;
    public Text useItemButtonTextNS;
    public GameObject useItemPanelNS;
    public Text useItemPanelTextNS;
    public GameObject confirmSellItemButtonNS;
    public GameObject sellItemButtonNS;
    public GameObject sellItemPanelNS;
    public Text sellItemTextPanelNS;
    public Text itemTitleNS;
    public Text itemDescriptionNS;
    public Text itemEquippedNS;
    #endregion
    #region Searched player
    public static GameObject searchButton;
    public static GameObject searchInputField;
    public static Text searchPlayerName;
    public static Text searchedPlayerAttack;
    public static Text searchedPlayerDef;
    public static Text searchedPlayerCash;
    public static Text searchedPlayerWR;
    public static Text searchedPlayerName;
    public static Text searchedPlayerXP;
    public static Text searchedPlayerLvl;
    public static Button searchedPlayerClassButton;
    public static Button searchedPlayerWeaponButton;
    public static Button searchedPlayerArmorButton;
    public static Button searchedPlayerMedallionButton;
    public GameObject searchButtonNS;
    public GameObject searchInputFieldNS;
    public Text searchPlayerNameNS;
    public Text searchedPlayerAttackNS;
    public Text searchedPlayerDefNS;
    public Text searchedPlayerCashNS;
    public Text searchedPlayerWRNS;
    public Text searchedPlayerNameNS;
    public Text searchedPlayerXPNS;
    public Text searchedPlayerLvlNS;
    public Button searchedPlayerClassButtonNS;
    public Button searchedPlayerWeaponButtonNS;
    public Button searchedPlayerArmorButtonNS;
    public Button searchedPlayerMedallionButtonNS;
    #endregion
    #region Bot Bar Panels
    public static int panelsLength = 10;
    public static GameObject[] panels = new GameObject[panelsLength];
    public GameObject[] panelsNS = new GameObject[panelsLength];
    #endregion
    #region Leaderboard
    public Text[] namesLeaderboardNS = new Text[5];
    public Text[] xpLeaderboardNS = new Text[5];
    public static Text[] namesLeaderboard = new Text[5];
    public static Text[] xpLeaderboard = new Text[5];
    #endregion
    #region Inventory Items/buttonsTBR
    public Button[] buttonsTBRNS = new Button[12];
    public static Button[] buttonsTBR = new Button[12];
    #endregion
    #region Shop Pages
    public static int currentCategory = 1;
    public static int[] categorySizes = new int[100];
    public static int currentPage = 1;
    public static GameObject[] shopPages1 = new GameObject[10];
    public static GameObject[] shopPages2 = new GameObject[10];
    public static GameObject[] shopPages3 = new GameObject[10];
    public static GameObject[] shopPages4 = new GameObject[10];
    public GameObject[] shopPages1NS = new GameObject[10];
    public GameObject[] shopPages2NS = new GameObject[10];
    public GameObject[] shopPages3NS = new GameObject[10];
    public GameObject[] shopPages4NS = new GameObject[10];
    #endregion
    #region Levels/maxXP
    public static int[] maxXP = new int[100];
    public static int numberOfLevels = 20;
    #endregion
    #region Items
    public static Item[] items = new Item[1000];
    public GameObject[] itemModels;
    public Sprite[] itemSpritesNS;
    #endregion
    #region Skills
    public static int skillsLength = 16;
    public static Skill[] skills = new Skill[60];
    public Sprite[] skillSpritesNS;
    #endregion
    #region Classes
    public static Class[] classes = new Class[4];
    public GameObject[] modelsNS;
    public Sprite[] classSpriteNS;
    public Sprite[] classSpriteHead;
    #endregion
    #region Fight
    public static GameObject[] fightPrefabs = new GameObject[100];
    public static GameObject playerModel;
    public static GameObject enemyModel;
    public static Skill[] possibleSkills = new Skill[60];
    public static Skill[] enemyPossibleSkills = new Skill[60];
    public static int randomSkill;
    public static int enemyRandomSkill;
    public static float playerHP;
    public static float enemyHP;
    public static Text playerHPText;
    public static Text enemyHPText;
    public static Text enemyNameText;
    public static GameObject turnPanel;
    public static Text BAtext;
    public static Text WBAtext;
    public static Text WStext;
    public static Text WS_SkillNametext;
    public static GameObject invisWBA;
    public static GameObject invisWS;
    public static GameObject topBarFight;
    public static GameObject BAbutton;
    public static GameObject WBAbutton;
    public static GameObject SAbutton;
    public static Text wonText;
    public static Text loseText;
    public GameObject[] fightPrefabsNS = new GameObject[100];
    public Text playerHPTextNS;
    public Text enemyHPTextNS;
    public Text enemyNameTextNS;
    public GameObject turnPanelNS;
    public Text BAtextNS;
    public Text WBAtextNS;
    public Text WStextNS;
    public Text WS_SkillNametextNS;
    public GameObject invisWBANS;
    public GameObject invisWSNS;
    public GameObject topBarFightNS;
    public GameObject BAbuttonNS;
    public GameObject WBAbuttonNS;
    public GameObject SAbuttonNS;
    public Text wonTextNS;
    public Text loseTextNS;
    #endregion
    #region Match History
    public GameObject matchHistoryGONS;
    public static GameObject matchHistoryGO;
    public static int playerHistorySize = 0;
    public static int playerHistoryCapacity = 1000;
    public static HistoryMatch[] playerHistory = new HistoryMatch[playerHistoryCapacity];
    public static HistoryMatch[] currentPlayerHistory = new HistoryMatch[playerHistoryCapacity];
    #endregion
    #region Spellbook
    public static Button[] spellSlots = new Button[15];
    public Button[] spellSlotsNS = new Button[15];
    public static Text spellTitle;
    public Text spellTitleNS;
    public static Text spellDescription;
    public Text spellDescriptionNS;
    public static GameObject spellUnlearnButton;
    public GameObject spellUnlearnButtonNS;
    public static int z;
    public static int lastSkillSelected;
    #endregion
    #region Arrows
    public static float difficulty;
    public static int numberOfArrows;
    public static GameObject[] arrows = new GameObject[4];
    public GameObject[] arrowsNS = new GameObject[4];
    public static Arrow[] arrowArray = new Arrow[1000];
    public static int score;
    public static Text scoreText; // The actual score (/500)
    public Text scoreTextNS;
    public static GameObject[] grayArrows = new GameObject[4];
    public GameObject[] grayArrowsNS = new GameObject[4];
    public static GameObject whiteAnim;
    public GameObject whiteAnimNS;
    public static GameObject yellowAnim;
    public GameObject yellowAnimNS;
    public static GameObject redAnim;
    public GameObject redAnimNS;
    #endregion
    #region Tutorial
    public Text currentTextNS;
    public GameObject tutorialNS;
    public static Text currentText;
    public static GameObject tutorial;
    public static int currentPageTutorial;
    #endregion

    void Awake () {

        Screen.SetResolution(1366, 768, true);

        #region Main Menu
        loginPanel = loginPanelNS;
        registerPanel = registerPanelNS;
        toggle = toggleNS;
        usernameTextLogin = usernameTextLoginNS;
        passwordTextLogin = passwordTextLoginNS;
        confEmailPanel = confEmailPanelNS;
        classPanel = classPanelNS;
        usernameTextRegister = usernameTextRegisterNS;
        passwordTextRegister = passwordTextRegisterNS;
        emailTextRegister = emailTextRegisterNS;
        #endregion
        #region Version
        updatePanel = updatePanelNS;
        #endregion
        #region Misc
        canvas = canvasNS;
        errorPanel = errorPanelNS;
        errorPanelText = errorPanelTextNS;
        wonPanel = wonPanelNS;
        lostPanel = lostPanelNS;
        loadingPanel = loadingPanelNS;
        successPanel = successPanelNS;
        successPanelText = successPanelTextNS;
        audioSliderMusicVolume = audioSliderMusicVolumeNS;
        infoHover = infoHoverNS;
        #endregion
        #region Player Stats
        currentPlayerAttack = currentPlayerAttackNS;
        currentPlayerCash = currentPlayerCashNS;
        currentPlayerDef = currentPlayerDefNS;
        currentPlayerLvl = currentPlayerLvlNS;
        currentPlayerName = currentPlayerNameNS;
        currentPlayerWR = currentPlayerWRNS;
        currentPlayerXP = currentPlayerXPNS;
        currentPlayerClassButton = currentPlayerClassButtonNS;
        currentPlayerArmorButton = currentPlayerArmorButtonNS;
        currentPlayerWeaponButton = currentPlayerWeaponButtonNS;
        currentPlayerMedallionButton = currentPlayerMedallionButtonNS;
        for (int i = 0; i < 3; i ++)
        {
            currentPlayerDefaultIcons[i] = currentPlayerDefaultIconsNS[i];
        }
        #endregion
        #region Item Shop
        confirmBuyItemButton = confirmBuyItemButtonNS;
        buyItemButton = buyItemButtonNS;
        buyItemPanel = buyItemPanelNS;
        itemTitleBuy = itemTitleBuyNS;
        itemDescriptionBuy = itemDescriptionBuyNS;
        itemPrice = itemPriceNS;
        itemLvlReqBuy = itemLvlReqBuyNS;
        itemClassesBuy = itemClassesBuyNS;
        #endregion
        #region Item inventory
        confirmUseItemButton = confirmUseItemButtonNS;
        useItemButton = useItemButtonNS;
        useItemText = useItemButtonTextNS;
        useItemPanel = useItemPanelNS;
        useItemPanelText = useItemPanelTextNS;
        confirmSellItemButton = confirmSellItemButtonNS;
        sellItemButton = sellItemButtonNS;
        sellItemPanel = sellItemPanelNS;
        sellItemTextPanel = sellItemTextPanelNS;
        itemTitle = itemTitleNS;
        itemDescription = itemDescriptionNS;
        itemEquipped = itemEquippedNS;
        #endregion
        #region Searched player
        searchButton = searchButtonNS;
        searchInputField = searchInputFieldNS;
        searchPlayerName = searchPlayerNameNS;
        searchedPlayerAttack = searchedPlayerAttackNS;
        searchedPlayerCash = searchedPlayerCashNS;
        searchedPlayerDef = searchedPlayerDefNS;
        searchedPlayerLvl = searchedPlayerLvlNS;
        searchedPlayerName = searchedPlayerNameNS;
        searchedPlayerWR = searchedPlayerWRNS;
        searchedPlayerXP = searchedPlayerXPNS;
        searchedPlayerClassButton = searchedPlayerClassButtonNS;
        searchedPlayerArmorButton = searchedPlayerArmorButtonNS;
        searchedPlayerWeaponButton = searchedPlayerWeaponButtonNS;
        searchedPlayerMedallionButton = searchedPlayerMedallionButtonNS;
        #endregion
        #region Bot Bar Panels
        for (int i = 0; i < panelsLength; i++)
        {
            panels[i] = panelsNS[i];
        }
        #endregion
        #region Leaderboard
        for (int i = 0; i < 5; i++)
        {
            namesLeaderboard[i] = namesLeaderboardNS[i];
            xpLeaderboard[i] = xpLeaderboardNS[i];
        }
        #endregion
        #region Inventory Items/buttonsTBR
        for (int i = 0; i < 12; i++)
        {
            buttonsTBR[i] = buttonsTBRNS[i];
        }
        #endregion
        #region Shop Pages
        categorySizes[0] = 1;
        categorySizes[1] = 1;
        categorySizes[2] = 4;
        categorySizes[3] = 1;
        for (int i = 0; i < categorySizes[0]; i ++)
        {
            shopPages1[i] = shopPages1NS[i];
        }
        for (int i = 0; i < categorySizes[1]; i++)
        {
            shopPages2[i] = shopPages2NS[i];
        }
        for (int i = 0; i < categorySizes[2]; i++)
        {
            shopPages3[i] = shopPages3NS[i];
        }
        for (int i = 0; i < categorySizes[3]; i++)
        {
            shopPages4[i] = shopPages4NS[i];
        }
        #endregion
        #region Levels/maxXP
        maxXP[0] = 0;
        maxXP[1] = 50;
        maxXP[2] = 125;
        maxXP[3] = 225;
        maxXP[4] = 350;
        maxXP[5] = 500;
        maxXP[6] = 675;
        maxXP[7] = 875;
        maxXP[8] = 1100;
        maxXP[9] = 1350;
        maxXP[10] = 1625;
        maxXP[11] = 1925;
        maxXP[12] = 2250;
        maxXP[13] = 2600;
        maxXP[14] = 2975;
        maxXP[15] = 3375;
        maxXP[16] = 3800;
        maxXP[17] = 4250;
        maxXP[18] = 4725;
        maxXP[19] = 5225;
        #endregion
        #region Items
        #region Medallions
        #region Game Tester Badge
        items[0] = new Item();
        items[0].i_id = 1;
        items[0].i_name = "Game Tester Badge";
        items[0].i_description = "Thank you!";
        items[0].i_price = 0;
        items[0].i_sprite = itemSpritesNS[0];
        items[0].i_lvlreq = 1;
        items[0].i_class = 0;
        items[0].i_go = null;
        items[0].i_skillsLength = 0;
        items[0].i_equipability = true;
        items[0].i_usability = false;
        items[0].i_type = 3;
        #endregion
        #region Crystal of Greed
        items[31] = new Item
        {
            i_id = 32,
            i_name = "Crystal of Greed",
            i_description = "This crystal can be a powerful tool in fights. However, it is a double-edged sword.",
            i_price = 300,
            i_sprite = itemSpritesNS[31],
            i_lvlreq = 4,
            i_class = 0,
            i_go = null,
            i_equipability = true,
            i_usability = false,
            i_type = 3,
            i_skillsLength = 0,
            i_def = -2,
            i_atk = 7
        };
        #endregion
        #endregion
        #region Weapons
        #region AK47
        items[1] = new Item
        {
            i_id = 2,
            i_name = "AK47 Rifle",
            i_description = "A very powerful rifle only wearable by soldiers. This ranged weapon is a must in any fight.",
            i_price = 600,
            i_sprite = itemSpritesNS[1],
            i_lvlreq = 4,
            i_class = 1,
            i_go = itemModels[1],
            i_equipability = true,
            i_usability = false,
            i_type = 1,
            i_skillsLength = 2,
            i_atk = 15
        };
        items[1].i_skills = new Skill[items[1].i_skillsLength];
        #region Skill 0 - Rapid Fire
        items[1].i_skills[0] = new Skill
        {
            s_id = 0,
            s_name = "Rapid Fire",
            s_description = "The Soldier temporarily enchants his AK47 to rapidly fire.",
            s_dmg = 5,
            s_weapon = 2,
            s_difficulty = 1f
        };
        #endregion
        #region Skill 1 - Mega Bullets
        items[1].i_skills[1] = new Skill
        {
            s_id = 1,
            s_name = "Mega Bullets",
            s_description = "The Soldier temporarily enchants his AK47 to shoot bigger bullets.",
            s_dmg = 10,
            s_weapon = 2,
            s_difficulty = 2f
        };
        #endregion
        #endregion
        #region M9Bayonet
        items[2] = new Item
        {
            i_id = 3,
            i_name = "M9 Bayonet",
            i_description = "It is not a simple knife, but a very efficient battle tool only wearable by soldiers.",
            i_price = 250,
            i_sprite = itemSpritesNS[2],
            i_lvlreq = 1,
            i_class = 1,
            i_go = itemModels[2],
            i_equipability = true,
            i_usability = false,
            i_type = 1,
            i_skillsLength = 2,
            i_atk = 8
        };
        items[2].i_skills = new Skill[items[2].i_skillsLength];
        #region Skill 0 - Fast Stab
        items[2].i_skills[0] = new Skill
        {
            s_id = 0,
            s_name = "Fast Stab",
            s_description = "The Soldier stabs the enemy quickly. Like, really quickly.",
            s_dmg = 8,
            s_weapon = 3,
            s_difficulty = 1.5f
        };
        #endregion
        #region Skill 1 - Fire Stab
        items[2].i_skills[1] = new Skill
        {
            s_id = 1,
            s_name = "Fire Stab",
            s_description = "The Soldier hits his enemy with his ardent M9Bayonet.",
            s_dmg = 15,
            s_weapon = 3,
            s_difficulty = 2.5f
        };
        #endregion
        #endregion
        #region Toxic Potion
        items[3] = new Item
        {
            i_id = 4,
            i_name = "Toxic Potion",
            i_description = "An extremely toxic potion. Can be used by mad scientists to irradiate their enemies.",
            i_price = 600,
            i_sprite = itemSpritesNS[3],
            i_lvlreq = 4,
            i_class = 2,
            i_go = itemModels[3],
            i_equipability = true,
            i_usability = false,
            i_type = 1,
            i_skillsLength = 2,
            i_atk = 13
        };
        items[3].i_skills = new Skill[items[3].i_skillsLength];
        #region Skill 0 - Death Potion
        items[3].i_skills[0] = new Skill
        {
            s_id = 0,
            s_name = "Death Potion",
            s_description = "In his madness, the mad scientist throws a death potion at his enemy to cause huge damage.",
            s_dmg = 10,
            s_weapon = 4,
            s_difficulty = 1.5f
        };
        #endregion
        #region Skill 1 - Mega Potion
        items[3].i_skills[1] = new Skill
        {
            s_id = 1,
            s_name = "Mega Potion",
            s_description = "The Mad Scientist throws out a huge toxic potion.",
            s_dmg = 20,
            s_weapon = 4,
            s_difficulty = 3f
        };
        #endregion
        #endregion
        #region Syringe
        items[4] = new Item
        {
            i_id = 5,
            i_name = "Syringe",
            i_description = "It stings. A lot.",
            i_price = 350,
            i_sprite = itemSpritesNS[4],
            i_lvlreq = 1,
            i_class = 2,
            i_go = itemModels[4],
            i_equipability = true,
            i_usability = false,
            i_type = 1,
            i_skillsLength = 2,
            i_atk = 10
        };
        items[4].i_skills = new Skill[items[4].i_skillsLength];
        #region Skill 0 - Toxic Syringe
        items[4].i_skills[0] = new Skill
        {
            s_id = 0,
            s_name = "Toxic Syringe",
            s_description = "The Mad Scientist enhances his syringe and makes it toxic, then inflicts a chunk of damage.",
            s_dmg = 8,
            s_weapon = 5,
            s_difficulty = 1.3f
        };
        #endregion
        #region Skill 1 - Fire Syringe
        items[4].i_skills[1] = new Skill
        {
            s_id = 1,
            s_name = "Fire Syringe",
            s_description = "It's lit. It's literally a lit syringe.",
            s_dmg = 15,
            s_weapon = 5,
            s_difficulty = 2f
        };
        #endregion
        #endregion
        #region Staff
        items[5] = new Item
        {
            i_id = 6,
            i_name = "Magic Staff",
            i_description = "A very powerful mage staff able to cast many spells. This is a must for all mage beginners.",
            i_price = 400,
            i_sprite = itemSpritesNS[5],
            i_lvlreq = 1,
            i_class = 3,
            i_go = itemModels[5],
            i_equipability = true,
            i_usability = false,
            i_type = 1,
            i_skillsLength = 2,
            i_atk = 8
        };
        items[5].i_skills = new Skill[items[5].i_skillsLength];
        #region Skill 0 - Fireballs
        items[5].i_skills[0] = new Skill
        {
            s_id = 0,
            s_name = "Fireballs",
            s_description = "The Mage throws fireballs at his enemies.",
            s_dmg = 6,
            s_weapon = 6,
            s_difficulty = 1
        };
        #endregion
        #region Skill 1 - Lightnings
        items[5].i_skills[1] = new Skill
        {
            s_id = 1,
            s_name = "Lightnings",
            s_description = "The Mage directs a storm towards his enemy.",
            s_dmg = 20,
            s_weapon = 6,
            s_difficulty = 2.3f
        };
        #endregion
        #endregion
        #region Shuriken
        items[6] = new Item
        {
            i_id = 7,
            i_name = "Shuriken",
            i_description = "Little, but hurtful. The ninja shurikens can deal a great amount of damage if used properly.",
            i_price = 300,
            i_sprite = itemSpritesNS[6],
            i_lvlreq = 1,
            i_class = 4,
            i_go = itemModels[6],
            i_equipability = true,
            i_usability = false,
            i_type = 1,
            i_skillsLength = 2,
            i_atk = 8
        };
        items[6].i_skills = new Skill[items[6].i_skillsLength];
        #region Skill 0 - Ice Shuriken
        items[6].i_skills[0] = new Skill
        {
            s_id = 0,
            s_name = "Ice Shuriken",
            s_description = "The Ninja throws ice shurikens at his enemies.",
            s_dmg = 5,
            s_weapon = 7,
            s_difficulty = 1f
        };
        #endregion
        #region Skill 1 - Double Shuriken
        items[6].i_skills[1] = new Skill
        {
            s_id = 1,
            s_name = "Double Shuriken",
            s_description = "The Ninja throws two shurikens for double trouble.",
            s_dmg = 10,
            s_weapon = 7,
            s_difficulty = 2f
        };
        #endregion
        #endregion
        #region Bow
        items[7] = new Item
        {
            i_id = 8,
            i_name = "Bow",
            i_description = "A basic ninja bow with pretty cool abilities. Nice to have.",
            i_price = 1500,
            i_sprite = itemSpritesNS[7],
            i_lvlreq = 7,
            i_class = 4,
            i_go = itemModels[7],
            i_equipability = true,
            i_usability = false,
            i_type = 1,
            i_skillsLength = 2,
            i_atk = 20
        };
        items[7].i_skills = new Skill[items[7].i_skillsLength];
        #region Skill 0 - Toxic Arrow
        items[7].i_skills[0] = new Skill
        {
            s_id = 0,
            s_name = "Toxic Arrow",
            s_description = "The Ninja fires a toxic arrow towards his enemy.",
            s_dmg = 7,
            s_weapon = 8,
            s_difficulty = 1.5f
        };
        #endregion
        #region Skill 1 - Fire Arrow
        items[7].i_skills[1] = new Skill
        {
            s_id = 1,
            s_name = "Fire Arrow",
            s_description = "The Mage directs a storm towards his enemy.",
            s_dmg = 15,
            s_weapon = 8,
            s_difficulty = 2.3f
        };
        #endregion
        #endregion
        #region Katana
        items[8] = new Item
        {
            i_id = 9,
            i_name = "Katana",
            i_description = "Dash'n'Slash with this awesome katana. It has a few skills.",
            i_price = 600,
            i_sprite = itemSpritesNS[8],
            i_lvlreq = 4,
            i_class = 4,
            i_go = itemModels[8],
            i_equipability = true,
            i_usability = false,
            i_type = 1,
            i_skillsLength = 2,
            i_atk = 15
        };
        items[8].i_skills = new Skill[items[8].i_skillsLength];
        #region Skill 0 - Fast Slice
        items[8].i_skills[0] = new Skill
        {
            s_id = 0,
            s_name = "Fast Slice",
            s_description = "The Ninja performs a super-quick slash.",
            s_dmg = 10,
            s_weapon = 9,
            s_difficulty = 1.9f
        };
        #endregion
        #region Skill 1 - Multislash
        items[8].i_skills[1] = new Skill
        {
            s_id = 1,
            s_name = "Multislash",
            s_description = "The Ninja performs 3 slashes on his enemy.",
            s_dmg = 20,
            s_weapon = 9,
            s_difficulty = 2.7f
        };
        #endregion
        #endregion
        #endregion
        #region Skill Scrolls
        #region Rapid Fire
        items[9] = new Item
        {
            i_id = 10,
            i_name = "Rapid Fire Scroll",
            i_description = "Using this scroll will make you learn the Rapid Fire skill.",
            i_price = 800,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 1,
            i_class = 1,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Mega Bullets
        items[10] = new Item
        {
            i_id = 11,
            i_name = "Mega Bullets Scroll",
            i_description = "Using this scroll will make you learn the Mega Bullets skill.",
            i_price = 1800,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 5,
            i_class = 1,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Fast Stab
        items[11] = new Item
        {
            i_id = 12,
            i_name = "Fast Stab Scroll",
            i_description = "Using this scroll will make you learn the Fast Stab skill.",
            i_price = 800,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 1,
            i_class = 1,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Fire Stab
        items[12] = new Item
        {
            i_id = 13,
            i_name = "Fire Stab Scroll",
            i_description = "Using this scroll will make you learn the Fire Stab skill.",
            i_price = 1600,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 5,
            i_class = 1,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Death Potion
        items[13] = new Item
        {
            i_id = 14,
            i_name = "Death Potion Scroll",
            i_description = "Using this scroll will make you learn the Death Potion skill.",
            i_price = 800,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 1,
            i_class = 2,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Mega Potion
        items[14] = new Item
        {
            i_id = 15,
            i_name = "Mega Potion Scroll",
            i_description = "Using this scroll will make you learn the Mega Potion skill.",
            i_price = 1600,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 5,
            i_class = 2,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Toxic Syringe
        items[15] = new Item
        {
            i_id = 16,
            i_name = "Toxic Syringe Scroll",
            i_description = "Using this scroll will make you learn the Toxic Syringe skill.",
            i_price = 1000,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 1,
            i_class = 2,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Fire Syringe
        items[16] = new Item
        {
            i_id = 17,
            i_name = "Fire Syringe Scroll",
            i_description = "Using this scroll will make you learn the Fire Syringe skill.",
            i_price = 1600,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 5,
            i_class = 2,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Fireballs
        items[17] = new Item
        {
            i_id = 18,
            i_name = "Fireballs Scroll",
            i_description = "Using this scroll will make you learn the Fireballs skill.",
            i_price = 800,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 2,
            i_class = 3,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Lightnings
        items[18] = new Item
        {
            i_id = 19,
            i_name = "Lightnings Scroll",
            i_description = "Using this scroll will make you learn the Lightnings skill.",
            i_price = 1600,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 5,
            i_class = 3,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Ice Shuriken
        items[19] = new Item
        {
            i_id = 20,
            i_name = "Ice Shuriken Scroll",
            i_description = "Using this scroll will make you learn the Ice Shuriken skill.",
            i_price = 800,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 1,
            i_class = 4,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Double Shuriken
        items[20] = new Item
        {
            i_id = 21,
            i_name = "Double Shuriken Scroll",
            i_description = "Using this scroll will make you learn the Double Shuriken skill.",
            i_price = 1200,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 3,
            i_class = 4,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Toxic Arrow
        items[21] = new Item
        {
            i_id = 22,
            i_name = "Toxic Arrow Scroll",
            i_description = "Using this scroll will make you learn the Toxic Arrow skill.",
            i_price = 800,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 1,
            i_class = 4,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Fire Arrow
        items[22] = new Item
        {
            i_id = 23,
            i_name = "Fire Arrow Scroll",
            i_description = "Using this scroll will make you learn the Fire Arrow skill.",
            i_price = 1600,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 5,
            i_class = 4,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Fast Slice
        items[23] = new Item
        {
            i_id = 24,
            i_name = "Fast Slice Scroll",
            i_description = "Using this scroll will make you learn the Fast Slice skill.",
            i_price = 800,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 1,
            i_class = 4,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #region Multislash
        items[24] = new Item
        {
            i_id = 25,
            i_name = "Multislash Scroll",
            i_description = "Using this scroll will make you learn the Multislash skill.",
            i_price = 1600,
            i_sprite = itemSpritesNS[9],
            i_lvlreq = 5,
            i_class = 4,
            i_go = null,
            i_skillsLength = 0,
            i_equipability = false,
            i_usability = true,
            i_type = 4
        };
        #endregion
        #endregion
        #region Armors
        #region Leather Armor
        items[25] = new Item
        {
            i_id = 26,
            i_name = "Leather Armor",
            i_description = "A leather armor to protect you in fights.",
            i_price = 400,
            i_sprite = itemSpritesNS[25],
            i_lvlreq = 1,
            i_class = 0,
            i_go = null,
            i_equipability = true,
            i_usability = false,
            i_type = 2,
            i_skillsLength = 0,
            i_def = 5
        };
        #endregion
        #region Bronze Armor
        items[26] = new Item
        {
            i_id = 27,
            i_name = "Bronze Armor",
            i_description = "A bronze armor. It's pretty neat.",
            i_price = 600,
            i_sprite = itemSpritesNS[26],
            i_lvlreq = 3,
            i_class = 0,
            i_go = null,
            i_equipability = true,
            i_usability = false,
            i_type = 2,
            i_skillsLength = 0,
            i_def = 10
        };
        #endregion
        #region Silver Armor
        items[27] = new Item
        {
            i_id = 28,
            i_name = "Silver Armor",
            i_description = "A shiny silver armor. Proceed with care.",
            i_price = 1000,
            i_sprite = itemSpritesNS[27],
            i_lvlreq = 5,
            i_class = 0,
            i_go = null,
            i_equipability = true,
            i_usability = false,
            i_type = 2,
            i_skillsLength = 0,
            i_def = 20
        };
        #endregion
        #region Golden Armor
        items[28] = new Item
        {
            i_id = 29,
            i_name = "Golden Armor",
            i_description = "A golden armor. It is known in all of Greece for its rarity.",
            i_price = 1800,
            i_sprite = itemSpritesNS[28],
            i_lvlreq = 8,
            i_class = 0,
            i_go = null,
            i_equipability = true,
            i_usability = false,
            i_type = 2,
            i_skillsLength = 0,
            i_def = 40
        };
        #endregion
        #region Platinum Armor
        items[29] = new Item
        {
            i_id = 30,
            i_name = "Platinum Armor",
            i_description = "A very heavy platinum armor. Only for the strongest of warriors.",
            i_price = 3400,
            i_sprite = itemSpritesNS[29],
            i_lvlreq = 12,
            i_class = 0,
            i_go = null,
            i_equipability = true,
            i_usability = false,
            i_type = 2,
            i_skillsLength = 0,
            i_def = 80
        };
        #endregion
        #region Ultimate Armor
        items[30] = new Item
        {
            i_id = 31,
            i_name = "Ultimate Armor",
            i_description = "An ultimate armor for the ultimate warriors. Its glitter makes it legendary.",
            i_price = 6600,
            i_sprite = itemSpritesNS[30],
            i_lvlreq = 20,
            i_class = 0,
            i_go = null,
            i_equipability = true,
            i_usability = false,
            i_type = 2,
            i_skillsLength = 0,
            i_def = 160
        };
        #endregion
        #endregion
        #endregion
        #region Skills
        skills[0] = items[1].i_skills[0];
        skills[1] = items[1].i_skills[1];
        skills[2] = items[2].i_skills[0];
        skills[3] = items[2].i_skills[1];
        skills[4] = items[3].i_skills[0];
        skills[5] = items[3].i_skills[1];
        skills[6] = items[4].i_skills[0];
        skills[7] = items[4].i_skills[1];
        skills[8] = items[5].i_skills[0];
        skills[9] = items[5].i_skills[1];
        skills[10] = items[6].i_skills[0];
        skills[11] = items[6].i_skills[1];
        skills[12] = items[7].i_skills[0];
        skills[13] = items[7].i_skills[1];
        skills[14] = items[8].i_skills[0];
        skills[15] = items[8].i_skills[1];
        #endregion
        #region Classes
        #region Class 0 - Soldier
        classes[0] = new Class
        {
            c_id = 0,
            c_name = "Soldier",
            c_atk = 104,
            c_def = 103,
            c_hp = 100,
            c_sprite = classSpriteNS[0],
            c_spriteHead = classSpriteHead[0],
            c_model = modelsNS[0]
        };
        #endregion
        #region Class 1 - Mad Scientist
        classes[1] = new Class
        {
            c_id = 1,
            c_name = "Mad Scientist",
            c_atk = 102,
            c_def = 96,
            c_hp = 100,
            c_sprite = classSpriteNS[1],
            c_spriteHead = classSpriteHead[1],
            c_model = modelsNS[1]
        };
        #endregion
        #region Class 2 - Mage
        classes[2] = new Class
        {
            c_id = 2,
            c_name = "Mage",
            c_atk = 107,
            c_def = 92,
            c_hp = 100,
            c_sprite = classSpriteNS[2],
            c_spriteHead = classSpriteHead[2],
            c_model = modelsNS[2]
        };
        #endregion
        #region Class 3 - Ninja
        classes[3] = new Class
        {
            c_id = 3,
            c_name = "Ninja",
            c_atk = 105,
            c_def = 96,
            c_hp = 100,
            c_sprite = classSpriteNS[3],
            c_spriteHead = classSpriteHead[3],
            c_model = modelsNS[3]
        };
        #endregion
        #endregion
        #region Fight
        for (int i = 0; i < 100; i ++)
        {
            fightPrefabs[i] = fightPrefabsNS[i];
        }
        playerHPText = playerHPTextNS;
        enemyHPText = enemyHPTextNS;
        turnPanel = turnPanelNS;
        BAtext = BAtextNS;
        WBAtext = WBAtextNS;
        WStext = WStextNS;
        WS_SkillNametext = WS_SkillNametextNS;
        invisWBA = invisWBANS;
        invisWS = invisWSNS;
        topBarFight = topBarFightNS;
        BAbutton = BAbuttonNS;
        wonText = wonTextNS;
        loseText = loseTextNS;
        WBAbutton = WBAbuttonNS;
        SAbutton = SAbuttonNS;
        #endregion
        #region Match History
        matchHistoryGO = matchHistoryGONS;
        for (int i = 0; i < playerHistoryCapacity; i ++)
        {
            playerHistory[i] = new HistoryMatch();
            currentPlayerHistory[i] = new HistoryMatch();
        }
        #endregion
        #region Spellbook 
        for (int i = 0; i < 15; i ++)
        {
            spellSlots[i] = spellSlotsNS[i];
        }
        spellTitle = spellTitleNS;
        spellDescription = spellDescriptionNS;
        spellUnlearnButton = spellUnlearnButtonNS;
        #endregion
        #region Arrows
        score = 0;
        numberOfArrows = 0;
        scoreText = scoreTextNS;
        for (int i = 0; i < 4; i++)
        {
            arrows[i] = arrowsNS[i];
            grayArrows[i] = grayArrowsNS[i];
        }
        whiteAnim = whiteAnimNS;
        yellowAnim = yellowAnimNS;
        redAnim = redAnimNS;
        #endregion
        #region Tutorial
        currentText = currentTextNS;
        tutorial = tutorialNS;
        #endregion
    }

    // Upload & Download Database Data
    public IEnumerator uploadAndSetDataIE()
    {
        yield return StartCoroutine(Camera.main.GetComponent<dataUploader>().uploadTheDataIE());
        yield return StartCoroutine(Camera.main.GetComponent<dataUploader>().uploadTheItemsIE());
        yield return StartCoroutine(Camera.main.GetComponent<dataShowerMain>().setAllIE());
        login.currentUser = dataLoader.usersM[login.currentUser.p_id - 1];
    }

    // Compute Player Level
    public static int playerLvl (int playerXp)
    {
        int currentPlayerLvlInt = 0;
        for (int j = 0; j < numberOfLevels; j++)
        {
            if (playerXp >= maxXP[j] && playerXp < maxXP[j + 1])
            {
                currentPlayerLvlInt = j + 1;
                break; 
            }
        }
        return currentPlayerLvlInt;
    }

    // Name to Id Method
    public static int nameToId (string name)
    {
        for (int i = 0; i < dataLoader.usersLength; i ++)
        {
            if (dataLoader.usersM[i].p_name == name)
            {
                return dataLoader.usersM[i].p_id;
            }
        }
        return -1;
    }

    // Attack Calculation
    public static void attackUpdate ()
    {
        login.currentUser.p_atk = classes[login.currentUser.p_class - 1].c_atk;
        if (login.currentUser.p_eqw != 0)
        {
            login.currentUser.p_atk += items[login.currentUser.p_eqw - 1].i_atk;
        }
        if (login.currentUser.p_eqm != 0)
        {
            login.currentUser.p_atk += items[login.currentUser.p_eqm - 1].i_atk;
        }
    }

    // Defense Calculation
    public static void defenseUpdate()
    {
        login.currentUser.p_def = classes[login.currentUser.p_class - 1].c_def;
        if (login.currentUser.p_eqa != 0)
        {
            login.currentUser.p_def += items[login.currentUser.p_eqa - 1].i_def;
        }
        if (login.currentUser.p_eqm != 0)
        {
            login.currentUser.p_def += items[login.currentUser.p_eqm - 1].i_def;
        }
    }

    // Attack Calculation Other Player
    public static void attackUpdateId (int id)
    {
        dataLoader.usersM[id - 1].p_atk = classes[dataLoader.usersM[id - 1].p_class - 1].c_atk;
        if (dataLoader.usersM[id - 1].p_eqw != 0)
        {
            dataLoader.usersM[id - 1].p_atk += items[dataLoader.usersM[id - 1].p_eqw - 1].i_atk;
        }
        if (dataLoader.usersM[id - 1].p_eqm != 0)
        {
            dataLoader.usersM[id - 1].p_atk += items[dataLoader.usersM[id - 1].p_eqm - 1].i_atk;
        }
    }

    // Attack Calculation Other Player
    public static void defenseUpdateId(int id)
    {
        dataLoader.usersM[id - 1].p_def = classes[dataLoader.usersM[id - 1].p_class - 1].c_def;
        if (dataLoader.usersM[id - 1].p_eqa != 0)
        {
            dataLoader.usersM[id - 1].p_def += items[dataLoader.usersM[id - 1].p_eqa - 1].i_def;
        }
        if (dataLoader.usersM[id - 1].p_eqm != 0)
        {
            dataLoader.usersM[id - 1].p_def += items[dataLoader.usersM[id - 1].p_eqm - 1].i_def;
        }
    }
}
