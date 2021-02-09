using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    StructBuild Village = new StructBuild(10, 10, 20, 100, 50, 20, 50, 0);
    StructBuild Farm = new StructBuild(10, 10, 20, 100, 50, 20, 50, 0);
    StructBuild Mine = new StructBuild(10, 10, 20, 100, 50, 20, 50, 0);
    private GameObject World;

    public StructBuild[] BuildingsNames;


    private void Start()
    {
        BuildingsNames = new StructBuild[] {Village, Farm, Mine};
        World = GameObject.Find("World");
    }

    public void NewBuild(int id, int BuildingId, GameObject ObjRegion)
    {
        Transform Region = ObjRegion.GetComponent<Region>().Regions[id].GetPosition();
        GameObject NewBuilding = World.GetComponent<WorldList>().Buildings[BuildingId];
        Vector2 Pos = new Vector2(ObjRegion.transform.position.x, ObjRegion.transform.position.y + 2);
        Instantiate(NewBuilding, Pos, Quaternion.identity, World.transform);
    }
}
