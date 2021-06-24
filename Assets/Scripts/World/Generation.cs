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
    //Pref of Advisers
    public GameObject PrefAdviser;


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


    #region Start Generate
    /// <summary>
    /// Generate regions
    /// </summary>
    /// <param name="length">How many regions</param>
    /// <param name="Pos">Global param of position</param>
    private void WorldGenerator(int length, Vector3 Pos)
    {
        for (int i = 0; i < length; i++)
        {
            GameObject Region = Instantiate(RegionsPrefabs[0], Pos, Quaternion.identity, gameObject.transform);
            Region.name = $"Region {i}";
            GenerateRegion(Region, i);
            if (i == 0 || i + 1 == length)
            {
                Transform Castle = SpawnCastle(Region);
                SpawnAdvisers(Castle);
            }
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
    #endregion

    private Transform SpawnCastle(GameObject ThisRegion)
    {
        Vector3 Pos = new Vector3(ThisRegion.transform.position.x, ThisRegion.transform.position.y + 1.9f, -1);
        GameObject Castle = Instantiate(RegionsPrefabs[1], Pos, Quaternion.identity, ThisRegion.transform);
        Castle.transform.localScale = new Vector3(2, 1.5f, 1);
        return Castle.transform;
    }

    private void SpawnAdvisers(Transform Castle)
    {
        Vector3 Pos = new Vector3(Castle.position.x - 1.5f, Castle.position.y + 2.5f, -1);
        for (int i = 0; i < 3; i++)
        {
            GameObject Adviser = Instantiate(PrefAdviser, Pos, Quaternion.identity, transform.Find("Player"));
            if (i == 1)
            {
                Adviser.GetComponent<SpriteRenderer>().sprite = GameObject.Find("World").GetComponent<WorldList>().UnitSprites[1];
                Adviser.GetComponent<Unit>().Parametrs.TypeOfAdviser = UnitParametrs.AdviserType.Spy;
            }
            else if (i == 2)
            {
                Adviser.GetComponent<SpriteRenderer>().sprite = GameObject.Find("World").GetComponent<WorldList>().UnitSprites[2];
                Adviser.GetComponent<Unit>().Parametrs.TypeOfAdviser = UnitParametrs.AdviserType.Architect;
            }
            
            Pos.x += 1.5f;
        }
    }

}
