using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] ResourceBuilding lumberMill;
    [SerializeField] ResourceBuilding stoneQuarry;
    [SerializeField] ResourceBuilding ironMine;
    [SerializeField] ResourceBuilding houses;

    [SerializeField] Text goldIncreaseText, woodIncreaseText, stoneIncreaseText, ironIncreaseText;

    [SerializeField] Text ironText;
    [SerializeField] Text stoneText;
    [SerializeField] Text woodText;
    [SerializeField] Text goldText;
    [SerializeField] Text popText;

    [SerializeField] public int woodCount = 3;
    [SerializeField] public int stoneCount = 0;
    [SerializeField] public int ironCount = 0;
    [SerializeField] public int goldCount = 5;
    [SerializeField] public int popCount = 0;

    public int[] woodUpgradeCost = new int[] { 5, 0 }; //Gold / Other
    public int[] stoneUpgradeCost = new int[] { 10, 2 };
    public int[] ironUpgradeCost = new int[] { 20, 5 };
    //int[] housesUpgradeCost = new int[] { 10, 0 };

    private void Start()
    {
        
    }

    void Update()
    {
        SetResourceText();
    }

    public void UpgradeBuilding()
    {

    }


    public void OnNextTurn()
    {

        woodCount += lumberMill.addResources();
        stoneCount += stoneQuarry.addResources();
        ironCount += ironMine.addResources();
        goldCount += houses.addTax();
       
    }


    private void SetResourceText()
    {
        ironText.text = "Iron: " + ironCount;
        stoneText.text = "Stone: " + stoneCount;
        woodText.text = "Wood: " + woodCount;
        goldText.text = "Gold: " + goldCount;
        popText.text = "Population: " + houses.population;

        goldIncreaseText.text = "(+" + houses.amountToAdd + ")";
        woodIncreaseText.text = "(+" + lumberMill.amountToAdd + ")";
        stoneIncreaseText.text = "(+" + stoneQuarry.amountToAdd + ")";
        ironIncreaseText.text = "(+" + ironMine.amountToAdd + ")";
    }


}
