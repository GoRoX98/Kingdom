using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public GameObject[] Regions;
    public int AmountOfRegions;


    void Awake()
    {
        Regions = GameObject.FindGameObjectsWithTag("Region");
        AmountOfRegions = Regions.Length;
        print(AmountOfRegions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
