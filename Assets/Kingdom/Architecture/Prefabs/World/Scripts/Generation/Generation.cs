using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField]
    GeneratorParametrs Parametrs = new GeneratorParametrs();
    //List of Regions on the map with self type (structure).
    public List<StructRegion> Regions = new List<StructRegion>();
    //Transform of Regions
    public List<Transform> RegionsTransform = new List<Transform>();
    //Pref of Advisers
    public GameObject PrefAdviser;
    //Other prefabs
    public List<GameObject> PrefabList = new List<GameObject>();
    //Player List
    public GameObject[] PlayerList;

    //Попытка реализовать равномерное распределение генерации непосредственно в редакторе (шансы)
/*    private void OnValidate()
    {
        int sum = 0;
        int difference = 0;

        if (!gameObject.activeInHierarchy) return;
        if (Parametrs.biomeChance.Count > 1)
        {
            for (int i = 0; i < Parametrs.biomeChance.Count; i++) sum += Parametrs.biomeChance[i];

            if (sum != 100)
            {
                difference = (100 - sum) / Parametrs.biomeChance.Count;
                for (int i = 0; i < Parametrs.biomeChance.Count; i++)
                {
                    Parametrs.biomeChance[i] += difference;
                }
            }
        }
    }*/


    private void Awake()
    {
        PlayerList = new GameObject[2];

        if (Parametrs.PVP == true)
        {

        }
        else
        {
            GameObject Player = Instantiate(PrefabList[0], GameObject.Find("Main Camera").transform);
            Player.name = "Player";
            GameObject AI = new GameObject("AI");
            AI.AddComponent<MyKingdom>();
            PlayerList[0] = Player;
            PlayerList[1] = AI;
        }
        Vector3 Pos = gameObject.transform.position;
        Pos.y -= 4;
        if (GetComponent<World>().Generation == true) WorldGenerator(GetComponent<World>().AmountOfRegions, Pos);
        else
        {
            GameObject[] RegionList = GameObject.FindGameObjectsWithTag("Region");
            for (int i = 0; i < RegionList.Length; i++)
            {
                GenerateRegion(RegionList[i], i);
                if (i < 2)
                {
                    SpawnAdvisers(GameObject.FindGameObjectsWithTag("Castle")[i].transform, PlayerList[i]);
                    PlayerList[i].GetComponent<MyKingdom>().MyCastle = GameObject.FindGameObjectsWithTag("Castle")[i];
                }
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
            GameObject Region = Instantiate(Parametrs.RegionsPrefabs[0], Pos, Quaternion.identity, gameObject.transform);
            Region.name = $"Region {i}";
            GenerateRegion(Region, i);
            if (i == 0 || i + 1 == length)
            {
                Transform Castle = SpawnCastle(Region);
                if (i == 0)
                {
                    PlayerList[0].GetComponent<MyKingdom>().MyCastle = Castle.gameObject;
                    SpawnAdvisers(Castle, PlayerList[0]);
                }
                else if (i + 1 == length)
                {
                    PlayerList[1].GetComponent<MyKingdom>().MyCastle = Castle.gameObject;
                    SpawnAdvisers(Castle, PlayerList[1]);
                }
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
        GameObject Castle = Instantiate(Parametrs.RegionsPrefabs[1], Pos, Quaternion.identity, ThisRegion.transform);
        Castle.transform.localScale = new Vector3(2, 1.5f, 1);
        return Castle.transform;
    }

    private void SpawnAdvisers(Transform Castle, GameObject Parent)
    {
        GameObject Advisers = new GameObject($"Advisers_{Parent.name}");
        Vector3 Pos = new Vector3(Castle.position.x - 1.5f, Castle.position.y + 2.5f, -1);
        for (int i = 0; i < 3; i++)
        {
            GameObject Adviser = Instantiate(PrefAdviser, Pos, Quaternion.identity, Advisers.transform);
            Adviser.name = "Capitan";
            if (i == 1)
            {
                Adviser.GetComponent<SpriteRenderer>().sprite = GameObject.Find("World").GetComponent<WorldList>().UnitSprites[1];
                Adviser.GetComponent<Unit>().Parametrs.TypeOfAdviser = UnitParametrs.AdviserType.Spy;
                Adviser.name = "Spy";
            }
            else if (i == 2)
            {
                Adviser.GetComponent<SpriteRenderer>().sprite = GameObject.Find("World").GetComponent<WorldList>().UnitSprites[2];
                Adviser.GetComponent<Unit>().Parametrs.TypeOfAdviser = UnitParametrs.AdviserType.Architect;
                Adviser.name = "Architect";
            }
            
            Pos.x += 1.5f;
        }
    }

}
