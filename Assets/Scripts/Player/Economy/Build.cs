using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject World;

    /// <summary>
    /// This function create a new building
    /// </summary>
    /// <param name="id">Id of selected region</param>
    /// <param name="BuildingId">Id of future building</param>
    /// <param name="ObjRegion">GameObject of selected region</param>
    public void NewBuild(int id, int BuildingId, GameObject ObjRegion)
    {
        if (verifyCost(BuildingId) == true)
        {
            //verefy owner
            if (ObjRegion.GetComponent<Region>().Owner(id) == 1)
            {
                GameObject NewBuilding = World.GetComponent<WorldList>().BuildingsGO[BuildingId];
                Vector2 Pos = new Vector2(ObjRegion.transform.position.x, ObjRegion.transform.position.y + 1.5f);
                Instantiate(NewBuilding, Pos, Quaternion.identity, World.transform);
                ObjRegion.GetComponent<Region>().Buildings.Add(World.GetComponent<WorldList>().BuildingsList[BuildingId]);
            }
            //WIP - make UI
            else print("Not your region");
        }
        else print("Not enough res");
    }

    /// <summary>
    /// This function verify cost of bulding and amount of player for try do it. 
    /// </summary>
    /// <param name="BuildingId">Id of building</param>
    /// <returns></returns>
    private bool verifyCost(int BuildingId)
    {
        int step = 0;
        int[] playerRes = GetComponent<Economy>().PlayerEconomy.GetResources();
        int[] cost = World.GetComponent<WorldList>().BuildingsList[BuildingId].GetCost();

        for (int i = 0; i < 3; i++)
        {
            if (playerRes[i] >= cost[i]) step++;
            else 
            {
                if (i == 0) print("Not enough food");
                if (i == 1) print("Not enough gold");
                if (i == 2) print("Not enough people");
            }
        }

        if (step == 3)
        {
            GetComponent<Economy>().PlayerEconomy.Spend(cost);
            return true;
        }
        else return false;
    }
}
