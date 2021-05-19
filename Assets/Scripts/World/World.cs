using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public GameObject[] Regions;
    public int AmountOfRegions;
    public bool Generation = true;


    private void Start()
    {
        Regions = GameObject.FindGameObjectsWithTag("Region");
    }
}
