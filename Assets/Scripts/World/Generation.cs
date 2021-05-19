using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    //Regions prefabs
    public List<GameObject> RegionsPrefabs = new List<GameObject>();
    //List of Regions on the map with self type (structure).
    public List<StructRegion> Regions = new List<StructRegion>();
    //Transform of Regions
    public List<Transform> RegionsTransform = new List<Transform>();


    private void Awake()
    {
        Vector3 Pos = gameObject.transform.position;
        Pos.y -= 4;
        if (GetComponent<World>().Generation == true) WorldGenerator(GetComponent<World>().AmountOfRegions, Pos);
        else
        {
            GameObject[] RegionList = GameObject.FindGameObjectsWithTag("Region");
            for (int i = 0; i < RegionList.Length; i++)
            {
                GenerateRegion(RegionList[i], i);
            }
        }
    }

    private void WorldGenerator(int length, Vector3 Pos)
    {
        for (int i = 0; i < length; i++)
        {
            GameObject Region = Instantiate(RegionsPrefabs[0], Pos, Quaternion.identity, gameObject.transform);
            Region.name = $"Region {i}";
            GenerateRegion(Region, i);
            Pos.x += 6;
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
        ThisRegion.GetComponent<Region>().SetId(i);
        Transform position;
        position = ThisRegion.transform;
        if (i < 2) Owner = 1;
        else Owner = 0;
        Regions.Add(new StructRegion(i, "Test Name", 0, position, Owner, ThisRegion));
        ThisRegion.GetComponent<Region>().SetStruct(Regions[i]);
    }
}
