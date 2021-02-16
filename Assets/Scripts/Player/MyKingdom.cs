using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKingdom : MonoBehaviour
{
    public GameObject World;


    public List<GameObject> MyDomain;
    //Amount of regions on the Map
    private int Amount;
    //Amount of regions of player kingdome
    private int MyAmount;
    //WIP - this for future, when player lose some regions and need del them from his MyDomain
    private int TempMyAmount = 0;
    private GameObject[] Regions;
    private int TempMonth;

    void Start()
    {
        Amount = GameObject.Find("World").GetComponent<World>().AmountOfRegions;
        Regions = GameObject.Find("World").GetComponent<World>().Regions;
        TempMonth = World.GetComponent<WorldTime>().GetTime()[1];
        MyTerritory();
    }

    void FixedUpdate()
    {
        
        if (TempMonth != World.GetComponent<WorldTime>().GetTime()[1])
        {
            MyTerritory();
            TempMonth = World.GetComponent<WorldTime>().GetTime()[1];
        }
    }

    /// <summary>
    /// Check territory of player's kingdome
    /// </summary>
    private void MyTerritory()
    {
        MyAmount = 0;
        for (int i = 0; i < Amount; i++)
        {
            if (Regions[i].GetComponent<Region>().Owner(i) == 1)
            {
                MyAmount++;
                if (MyDomain.Count < MyAmount) MyDomain.Add(Regions[i]);
            }
        }
        TempMyAmount = MyAmount;
        
    }

    /// <summary>
    /// Income from player's kingdome
    /// </summary>
    /// <returns>Food, Gold, People</returns>
    public int[] DomainIncome()
    {
        //food, gold, people
        int[] Income = new int[3] {10, 10, 10};

        for (int i = 0; i < MyDomain.Count; i++)
        {
            List<StructBuild> Buildings = MyDomain[i].GetComponent<Region>().Buildings;
            for (int b = 0; b < Buildings.Count; b++)
            {
                Income[0] += Buildings[b].GetIncome()[0];
                Income[1] += Buildings[b].GetIncome()[1];
                Income[2] += Buildings[b].GetIncome()[2];
            }
        }

        return Income;
    }


}
