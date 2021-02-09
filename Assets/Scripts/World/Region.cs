using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Prototype of generation parametrs for regions on the scene
/// </summary>
public class Region : MonoBehaviour
{
    /// <param name = "Regions" > List of Regions on the map with self type (structure).</param>
    public StructRegion[] Regions;
    [SerializeField]
    /// <param name="TestId"> Id of Regions. Costil for using in others scripts</param>
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
        Transform position;
        position = ThisRegion.transform;
        if (i < 2) Owner = 1;
        else Owner = 0;
        Regions[i] = new StructRegion(i, "Test Name", 0, position, Owner, ThisRegion);
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