using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Черновая генерация параметров регионов и их присвоение к объектам на сцене
/// </summary>
public class Region : MonoBehaviour
{
    public StructRegion[] Regions;
    [SerializeField]
    private int TestId;

    void Start()
    {
        GameObject[] RegionNum = GameObject.Find("World").GetComponent<World>().Regions;
        int Amount = GameObject.Find("World").GetComponent<World>().AmountOfRegions;
        Regions = new StructRegion[Amount];
        for (int i = 0; i < Amount; i++)
        {
            GenerateRegion(RegionNum[i], i);        
        }
    }




    private void GenerateRegion(GameObject ThisRegion, int i)
    {
        int Owner;
        ThisRegion.GetComponent<Region>().TestId = i;
        float[] coordinate = new float[2];
        coordinate[0] = ThisRegion.transform.position.x;
        coordinate[1] = ThisRegion.transform.position.y;
        if (i < 2) Owner = 1;
        else Owner = 0;
        Regions[i] = new StructRegion(i, "Test Name", 0, coordinate, Owner);

    }

    public void InfoRegion(GameObject InfoRegion)
    {
        print($"Информация: {Regions[InfoRegion.GetComponent<Region>().TestId].PrintInfo()}");
    }

    public int Id()
    {
        return TestId;
    }

    public int Owner(int id)
    {
        return Regions[id].InfoOwner();
    }
}