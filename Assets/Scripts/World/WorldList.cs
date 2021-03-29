using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldList : MonoBehaviour
{
    //List of Regions on the map with self type (structure).
    public List<StructRegion> Regions;

    //List GO of builddings
    public List<GameObject> BuildingsGO = new List<GameObject>();
    //List structure of buildings
    public List<StructBuild> BuildingsList = new List<StructBuild>();
    //List of Seasons in the year
    public List<string> Season = new List<string> { "Spring", "Summer", "Autumn", "Winter" };
    //List of Month
    public List<string> Month = new List<string> { "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "Junuary", "February" };
    //Type of Soldires
    public List<Soldiers> SoldiresDB = new List<Soldiers>();
    //Sprites for units
    public List<Sprite> UnitSprites = new List<Sprite>();
    //Transform of Regions
    public List<Transform> RegionsTransform = new List<Transform>();

    void Awake()
    {
        BuildingsList.Add(new StructBuild ("Village", 0, 10, 20, 100, 50, 20, 50, 0));
        BuildingsList.Add(new StructBuild ("Farm", 25, 10, 0, 100, 50, 20, 50, 1));
        BuildingsList.Add(new StructBuild ("Mine", -10, 30, -5, 100, 50, 20, 50, 2));

        GameObject[] RegionNum = GameObject.Find("World").GetComponent<World>().Regions;
        int Amount = GameObject.Find("World").GetComponent<World>().AmountOfRegions;
        Regions = new List<StructRegion>();
        for (int i = 0; i < Amount; i++)
        {
            GenerateRegion(RegionNum[i], i);
        }
    }

    void Start()
    {

    }

    /// <summary>
    /// Generate structure for this region
    /// </summary>
    /// <param name="ThisRegion">GameObject of region</param>
    /// <param name="i">Id of region</param>
    private void GenerateRegion(GameObject ThisRegion, int i)
    {
        int Owner;
        ThisRegion.GetComponent<Region>().SetId(i);
        Transform position;
        position = ThisRegion.transform;
        if (i < 2) Owner = 1;
        else Owner = 0;
        Regions.Add(new StructRegion(i, "Test Name", 0, position, Owner, ThisRegion));
        ThisRegion.GetComponent<Region>().SetStruct(Regions[i]);
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
