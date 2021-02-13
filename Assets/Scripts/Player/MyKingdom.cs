using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKingdom : MonoBehaviour
{
    public GameObject World;


    private GameObject[] MyDomain;
    private int Amount;
    private GameObject[] Regions;
    private int TempMonth;

    void Start()
    {
        Amount = GameObject.Find("World").GetComponent<World>().AmountOfRegions;
        Regions = GameObject.Find("World").GetComponent<World>().Regions;
        MyDomain = new GameObject[Amount];
        TempMonth = World.GetComponent<WorldTime>().GetTime()[1];
        MyTerritory(MyDomain, Amount, Regions);
    }

    void FixedUpdate()
    {
        
        if (TempMonth != World.GetComponent<WorldTime>().GetTime()[1])
        {
            MyTerritory(MyDomain, Amount, Regions);
            TempMonth = World.GetComponent<WorldTime>().GetTime()[1];
        }
    }

    private void MyTerritory(GameObject[] MyRegions, int Amount, GameObject[] WorldRegions)
    {
        for (int i = 0; i < Amount; i++)
        {
            if (WorldRegions[i].GetComponent<Region>().Owner(i) == 1)
            {
                MyDomain[i] = WorldRegions[i];
            }
        }
    }


}
