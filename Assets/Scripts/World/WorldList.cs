using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldList : MonoBehaviour
{
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

    void Awake()
    {
        BuildingsList.Add(new StructBuild ("Village", 0, 10, 20, 100, 50, 20, 50, 0));
        BuildingsList.Add(new StructBuild("Farm", 25, 10, 0, 100, 50, 20, 50, 1));
        BuildingsList.Add(new StructBuild("Mine", -10, 30, -5, 100, 50, 20, 50, 2));
    }

}
