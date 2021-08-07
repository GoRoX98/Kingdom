using System.IO;
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
    //Sprites for units
    public List<Sprite> UnitSprites = new List<Sprite>();

    //Test DB
    public Soldiers[] TestDB;
    void Awake()
    {
        BuildingsList.Add(new StructBuild ("Village", 0, 10, 20, 100, 50, 20, 50, 0));
        BuildingsList.Add(new StructBuild ("Farm", 25, 10, 0, 100, 50, 20, 50, 1));
        BuildingsList.Add(new StructBuild ("Mine", -10, 30, -5, 100, 50, 20, 50, 2));

        SaveOLDDB();
        //LoadSoldiersDB();
    }

    private void LoadSoldiersDB()
    {
        string Json = File.ReadAllText(Application.dataPath + "/Kingdom/Resources/Soldiers.json");

        TestDB = JsonUtility.FromJson<Soldiers[]>(Json);


        print(TestDB.Length);
        print(Json);
    }

    private void SaveOLDDB()
    {
        int i = SoldiresDB.Count;
        Soldiers[] Test = new Soldiers[] {};
        for (int b = 0; b<i; b++)
        {
            Test[b] = new Soldiers
            (
                SoldiresDB[b].Name,
                SoldiresDB[b].Damage,
                SoldiresDB[b].Deffense,
                SoldiresDB[b].Speed,
                SoldiresDB[b].Morale,
                SoldiresDB[b].HireGold,
                SoldiresDB[b].HireFood,
                SoldiresDB[b].HireTime
            );
        }

        string json = JsonUtility.ToJson(Test, true);
        File.WriteAllText(Application.dataPath + "/Kingdom/Resources/TestFile.json", json);
    }
}
