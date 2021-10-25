using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GameObject[] wallBlocks;

    private GameObject currentObject;
    private GameObject previousObject;
    private Color previousColor;
    private Color currentColor;
    [SerializeField] Color32 newColor = Color.black;

    [SerializeField] GameObject protBarrier;
    [SerializeField] GameObject defUpgradePopup;
    [SerializeField] GameObject upgradePopup;
    [SerializeField] GameObject wallPopup;
    [SerializeField] GameObject housesPopup;
    [SerializeField] Text upgradeTimerText;
    [SerializeField] Text upgradeText;
    [SerializeField] Text popAmountText;
    [SerializeField] Text housesAmountText;
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] TurnManager turnManager;

    [SerializeField] ResourceBuilding LumberMill;
    [SerializeField] ResourceBuilding StoneQuarry;
    [SerializeField] ResourceBuilding IronMine;
    [SerializeField] ResourceBuilding Houses;

    [SerializeField] int lumberMillIncrease = 1;
    [SerializeField] int stoneQuarryIncrease = 1;
    [SerializeField] int ironMineIncrease = 1;
    [SerializeField] int housesIncrease = 1;

    [SerializeField] int woodBlockCost = 1;
    [SerializeField] int stoneBlockCost = 1;
    [SerializeField] int ironBlockCost = 1;


    GameObject currentBlock;
    string currentName = "";
    string currentObjectName = "";
    int currentLevel = 0;
    float currentTime = 0;
    float totalTime = 10f;
    bool startTimer = false;
    float tempInt;

    string currentMaterial = "";


    // Start is called before the first frame update
    void Start()
    {
        protBarrier.SetActive(false);
        upgradeTimerText.enabled = false;
        defUpgradePopup.SetActive(false);
        upgradePopup.SetActive(false);
        wallPopup.SetActive(false);
        housesPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            if (currentTime > 0)
            {
                currentTime -= 1 * Time.deltaTime;
                upgradeTimerText.text = currentTime.ToString();
            }
            else
            {
                upgradeTimerText.enabled = false;
                turnManager.setDamage(tempInt);
                protBarrier.SetActive(false);
                startTimer = false;
 
            }
        }
    }

    public void openDefPopup()
    {
        defUpgradePopup.SetActive(true);
    }

    public void closeDefPopup()
    {
        defUpgradePopup.SetActive(false);
    }

    public void useBarrier()
    {
        protBarrier.SetActive(true);
        currentTime = totalTime;
        tempInt = turnManager.damage;
        turnManager.setDamage(0f);
        upgradeTimerText.enabled = true;
        startTimer = true;
    }

    public void closeWallPopup()
    {
        wallPopup.SetActive(false);
        previousObject.GetComponent<SpriteRenderer>().color = previousColor;
    }

    public void createWallPopup(string material, string objectName)
    {
        setSelectionColour(objectName);

        wallPopup.SetActive(true);
        currentMaterial = material;
        currentObjectName = objectName;


    }

    private void setSelectionColour(string objectName)
    {
        if (previousObject != null)
        {
            if (previousObject.GetComponent<SpriteRenderer>().color == newColor)
            {
                previousObject.GetComponent<SpriteRenderer>().color = previousColor;
            }
        }

        currentObject = GameObject.Find(objectName);
        previousColor = currentObject.GetComponent<SpriteRenderer>().color;
        previousObject = currentObject;

        if (currentObject.GetComponent<SpriteRenderer>().color != newColor)
        {
            currentObject.GetComponent<SpriteRenderer>().color = newColor;
        }
    }

    public void buildWoodWall()
    {
        if (resourceManager.woodCount >= woodBlockCost)
        {
            resourceManager.woodCount -= woodBlockCost;
            currentBlock = GameObject.Find(currentObjectName);
            currentBlock.GetComponent<WallBlock>().updateBlock("Wood");
        }
        scoreManager.updateScore(1, "wood");
    }

    public void buildStoneWall()
    {
        if (resourceManager.stoneCount >= stoneBlockCost)
        {
            resourceManager.stoneCount -= stoneBlockCost;
            currentBlock = GameObject.Find(currentObjectName);
            currentBlock.GetComponent<WallBlock>().updateBlock("Stone");
        }
        scoreManager.updateScore(1, "stone");
    }

    public void buildIronWall()
    {
        if (resourceManager.ironCount >= ironBlockCost){
            resourceManager.ironCount -= ironBlockCost;
            currentBlock = GameObject.Find(currentObjectName);
            currentBlock.GetComponent<WallBlock>().updateBlock("Iron");
        }
        scoreManager.updateScore(1, "iron");
    }


    public void UpgradeBuilding()
    {
        switch (currentName)
        {
            case "LumberMill":
                WoodUpgrade();
                break;

            case "StoneQuarry":
                StoneUpgrade();
                break;

            case "IronMine":
                IronUpgrade();
                break;

            case "Houses":
                HousesUpgrade();
                break;
        }
        resourceManager.UpgradeBuilding();
    }

    public void closeHousesPopup()
    {
        housesPopup.SetActive(false);
        previousObject.GetComponent<SpriteRenderer>().color = previousColor;
    }
    public void HousesUpgrade()
    {
        if (resourceManager.goldCount >= resourceManager.woodUpgradeCost[0])
        {
            Houses.Build();
            resourceManager.goldCount -= resourceManager.woodUpgradeCost[0];
            currentLevel += 1;
            HousesUpgradeText();
            scoreManager.updateScore(1, "houses");
        }
    }

    private void IronUpgrade()
    {
        if (resourceManager.goldCount >= resourceManager.woodUpgradeCost[0] && resourceManager.stoneCount >= resourceManager.ironUpgradeCost[1])
        {
            IronMine.Upgrade(ironMineIncrease);
            resourceManager.goldCount -= resourceManager.ironUpgradeCost[0];
            resourceManager.stoneCount -= resourceManager.ironUpgradeCost[1];
            currentLevel += 1;
            IronUpgradeText();
            scoreManager.updateScore(1, "mine");
        }
    }

    private void StoneUpgrade()
    {
        if (resourceManager.goldCount >= resourceManager.stoneUpgradeCost[0] && resourceManager.woodCount >= resourceManager.stoneUpgradeCost[1])
        {
            StoneQuarry.Upgrade(stoneQuarryIncrease);
            resourceManager.goldCount -= resourceManager.stoneUpgradeCost[0];
            resourceManager.woodCount -= resourceManager.stoneUpgradeCost[1];
            currentLevel += 1;
            StoneUpgradeText();
            scoreManager.updateScore(1, "quarry");
        }
    }

    private void WoodUpgrade()
    {
         if (resourceManager.goldCount >= resourceManager.woodUpgradeCost[0])
        {
            LumberMill.Upgrade(lumberMillIncrease);
            resourceManager.goldCount -= resourceManager.woodUpgradeCost[0];
            currentLevel += 1;
            WoodUpgradeText();
            scoreManager.updateScore(1, "lumber");
        }
    }

    public void closePopup()
    {
        upgradePopup.SetActive(false);
        previousObject.GetComponent<SpriteRenderer>().color = previousColor;
    }

    public void createPopup(string Name, int level, String currentResourceObject)
    {
        setSelectionColour(currentResourceObject);

        currentName = Name;
        currentLevel = level;

        switch (currentName)
        {
            case "LumberMill":
                housesPopup.SetActive(false);
                upgradePopup.SetActive(true);
                WoodUpgradeText();
                break;

            case "StoneQuarry":
                housesPopup.SetActive(false);
                upgradePopup.SetActive(true);
                StoneUpgradeText();
                break;

            case "IronMine":
                housesPopup.SetActive(false);
                upgradePopup.SetActive(true);
                IronUpgradeText();
                break;

            case "Houses":
                upgradePopup.SetActive(false);
                housesPopup.SetActive(true);
                HousesUpgradeText();
                break;
        }

    }

    private void HousesUpgradeText()
    {
        housesAmountText.text = "Amount of houses: " + currentLevel + "\nCost to build a house: " + resourceManager.woodUpgradeCost[0] + "x Gold.";
        popAmountText.text = "Population count: " + resourceManager.popCount;
    }

    private void IronUpgradeText()
    {
        upgradeText.text = "Current Level: " + currentLevel + "\nDo you want to upgrade your " +
                            currentName + "? This upgrade will cost: " + resourceManager.ironUpgradeCost[0] +
                            "x Gold and " + resourceManager.ironUpgradeCost[1] + "x Stone.";
    }

    private void StoneUpgradeText()
    {
        upgradeText.text = "Current Level: " + currentLevel + "\nDo you want to upgrade your " +
                            currentName + "? This upgrade will cost: " + resourceManager.stoneUpgradeCost[0] +
                            "x Gold and " + resourceManager.stoneUpgradeCost[1] + "x Wood.";
    }

    private void WoodUpgradeText()
    {
        upgradeText.text = "Current Level: " + currentLevel + "\nDo you want to upgrade your " +
                            currentName + "? This upgrade will cost: " + resourceManager.woodUpgradeCost[0] +
                            "x Gold";
    }


}
