using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Черновая генерация параметров регионов и их присвоение к объектам на сцене
/// </summary>
public class Region : MonoBehaviour
{

    private GameObject[] AmountOfRegions;
    public StructRegion[] Regions;
    [SerializeField]
    private int TestId;

    void Start()
    {
        AmountOfRegions = GameObject.FindGameObjectsWithTag("Region");
        int length = AmountOfRegions.Length;
        print(length);
        Regions = new StructRegion[length];

        for (int i = 0; i < length; i++)
        {
            GenerateRegion(AmountOfRegions[i], i);        
        }
    }




    private void GenerateRegion(GameObject ThisRegion, int i)
    {
        ThisRegion.GetComponent<Region>().TestId = i;
        float[] coordinate = new float[2];
        coordinate[0] = ThisRegion.transform.position.x;
        coordinate[1] = ThisRegion.transform.position.y;
        Regions[i] = new StructRegion(i, "Test Name", 0, coordinate);

    }

    public void InfoRegion(GameObject InfoRegion)
    {
        print($"Информация: {Regions[InfoRegion.GetComponent<Region>().TestId].PrintInfo()}");
    }

    public int Id()
    {
        return TestId;
    }
}