using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKingdom : MonoBehaviour
{
    private GameObject[] MyDomain;
    private int Amount;
    private GameObject[] Regions;
    private float timer = 0;

    void Awake()
    {
        Amount = GameObject.Find("World").GetComponent<World>().AmountOfRegions;
        Regions = GameObject.Find("World").GetComponent<World>().Regions;
        MyDomain = new GameObject[Amount];
        MyTerritory(MyDomain, Amount, Regions);
        print($"My regions: {MyDomain.Length}");
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            MyTerritory(MyDomain, Amount, Regions);
            timer = 0;
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

    public GameObject[] GetDomain()
    {
        return MyDomain;
    }
}
