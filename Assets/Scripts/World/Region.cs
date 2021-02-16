using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Prototype of generation parametrs for regions on the scene
/// </summary>
public class Region : MonoBehaviour
{
    //List of Regions on the map with self type (structure).
    public StructRegion[] Regions;
    [SerializeField]
    //Id of Regions. Costil for using in others scripts
    private int TestId;
    //List of buildings in this region
    public List<StructBuild> Buildings = new List<StructBuild>();

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



    /// <summary>
    /// Generate structure for this region
    /// </summary>
    /// <param name="ThisRegion">GameObject of region</param>
    /// <param name="i">Id of region</param>
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

    /// <summary>
    /// Who owner
    /// </summary>
    /// <param name="id">Id of region</param>
    /// <returns>Id of owner</returns>
    public int Owner(int id)
    {
        return Regions[id].InfoOwner();
    }

    
}