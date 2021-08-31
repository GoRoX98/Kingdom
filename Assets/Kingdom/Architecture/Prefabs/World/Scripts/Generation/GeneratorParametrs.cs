using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GeneratorParametrs
{
    //1 or 2 players
    public bool PVP;
    //% chance of spawn biome
    [Range(0, 100)]
    public List<int> biomeChance;
    //Regions prefabs
    public List<GameObject> RegionsPrefabs = new List<GameObject>();
}
