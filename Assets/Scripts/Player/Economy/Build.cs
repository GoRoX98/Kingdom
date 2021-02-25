using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject World;
    public GameObject PlayerUI;

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
            //verify owner
            if (ObjRegion.GetComponent<Region>().Owner(id) == 1)
            {
                //how many buildings we can build in the region WIP
                if (ObjRegion.GetComponent<Region>().Buildings.Count < 3)
                {
                    GameObject NewBuilding = World.GetComponent<WorldList>().BuildingsGO[BuildingId];
                    Vector3 Pos = Position(ObjRegion);
                    Instantiate(NewBuilding, Pos, Quaternion.identity, World.transform);
                    ObjRegion.GetComponent<Region>().Buildings.Add(World.GetComponent<WorldList>().BuildingsList[BuildingId]);
                }
                else
                {
                    print("Max buildings in region");
                    GameObject NewWindow = PlayerUI.GetComponent<PlayerUI>().PrefsUI[0];
                    Instantiate(NewWindow);
                }
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

    private Vector3 Position(GameObject Region)
    {
        Vector3 position;

        if (Region.GetComponent<Region>().Buildings.Count == 0) position = new Vector3(Region.transform.position.x - 2.0f, Region.transform.position.y + 1.3f, 1.0f);

        else if (Region.GetComponent<Region>().Buildings.Count == 1) position = new Vector3(Region.transform.position.x, Region.transform.position.y + 1.3f, 1.0f);

        else position = new Vector3(Region.transform.position.x + 2.0f, Region.transform.position.y + 1.3f, 1.0f);

        return position;
    }
}
