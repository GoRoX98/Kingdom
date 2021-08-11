using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class CreateArmy : MonoBehaviour
{

    public GameObject World;
    public GameObject Player;
    public GameObject Prefab;
    public GameObject Parent;

    public List<Text> fields;
    //Amount soldires in kingdom
    private int[] amount;
    //How many hire
    private int[] HowMany;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        World = GameObject.Find("World");
        amount = Player.GetComponent<MyKingdom>().AllSoldires();
        HowMany = new int[amount.Length];
    }

    void Start()
    {
        List<Soldiers> soldiersList = World.GetComponent<WorldList>().Resources.Soldiers;
    }



    /// <summary>
    /// Spawn Army GameObject.
    /// Castle - предстоит переписать, пока не знаю как логически игра будет определять Игрок 1 или Игрок 2.
    /// Костыль.
    /// </summary>
    /// <param name="Army">GO of Army on the Scene</param>
    public void HireArmy(GameObject Army)
    {
        bool check = false;
        for (int i =0; HowMany.Length > i; i++)
        {
            if (HowMany[i] > 0) check = true;
        }

        if (check == true)
        {
            Army.GetComponent<Army>().ArmyStructure.ArmyStruct = HowMany;
            Army.GetComponent<Army>().ArmyStructure.Soldires = GameObject.Find("World").GetComponent<WorldList>().Resources.Soldiers;
            GameObject Castle = GameObject.FindGameObjectWithTag("Player").GetComponent<MyKingdom>().MyCastle;
            Vector3 Pos = new Vector3(Castle.transform.position.x, Castle.transform.position.y - 1f, Castle.transform.position.z - 1f);
            Instantiate(Army, Pos, Quaternion.identity, GameObject.Find("World").GetComponent<Transform>());
        }
        else print("Cant create");
    }

}
