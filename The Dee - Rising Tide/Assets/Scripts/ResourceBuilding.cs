using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuilding : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] UpgradeManager upgradeManager;

    [SerializeField] public int amountToAdd = 0;
    [SerializeField] string Name = "";
    [SerializeField] int level = 1;
    [SerializeField] public int population = 5;

    private void Start()
    {
        SetupBuilding();
    }

    private void SetupBuilding()
    {

        if (tag == "LumberMill")
        {
            amountToAdd = 4;
            Name = "LumberMill";
        }
        else if (tag == "StoneQuarry")
        {
            amountToAdd = 0;
            Name = "StoneQuarry";
        }
        else if (tag == "IronMine")
        {
            amountToAdd = 0;
            Name = "IronMine";
        }
        else if (tag == "Houses")
        {
            amountToAdd = 3;
            Name = "Houses";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }


    private void OnMouseDown()
    {
        GameObject currentObject = gameObject;
        upgradeManager.createPopup(Name, level, currentObject.name);
    }

    public string getName()
    {
        return Name;
    }

    public void Upgrade(int increase)
    {
        level += 1;
        amountToAdd += increase;
    }

    public void Build()
    {
        level += 1;
        int newPops = UnityEngine.Random.Range(1, 6);
        population += newPops;
        switch (newPops)
        {
            case 1: amountToAdd += 6;
                break;
            case 2: amountToAdd += 5;
                break;
            case 3: amountToAdd += 4;
                break;
            case 4: amountToAdd += 3;
                break;
            case 5: amountToAdd += 2;
                break;
            case 6: amountToAdd += 1;
                break;
        }
        Debug.Log(amountToAdd);

    }

    public int addResources()
    {
        return amountToAdd;
    }

    public int addTax()
    {
        return amountToAdd;
    }
}
