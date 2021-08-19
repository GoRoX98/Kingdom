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
        Parent = gameObject.transform.Find("Canvas").Find("Hire").Find("Soldiers Layout").gameObject;
        listGenerator(soldiersList.Count, soldiersList);
    }

    private void listGenerator(int i, List<Soldiers> soldiersList)
    {
        int[] soldiresAmount = Player.GetComponent<MyKingdom>().AllSoldires();
        for (int b = 0; b < i; b++)
        {
            GameObject newObj = Instantiate(Prefab, Parent.transform);
            newObj.GetComponent<ListUI>().TextFields[2].text = soldiersList[b].Name;
            newObj.GetComponent<ListUI>().TextFields[1].text = soldiresAmount[b].ToString();
        }
    }


    /// <summary>
    /// Spawn Army GameObject.
    /// Castle - предстоит переписать, пока не знаю как логически игра будет определять Игрок 1 или Игрок 2.
    /// Костыль.
    /// </summary>
    /// <param name="Army">GO of Army on the Scene</param>
    public void HireArmy(GameObject Army)
    {
        Army.GetComponent<Army>().ArmyStructure.ArmyStruct = HowMany;
        Army.GetComponent<Army>().ArmyStructure.Soldires = GameObject.Find("World").GetComponent<WorldList>().Resources.Soldiers;
        GameObject Castle = GameObject.FindGameObjectWithTag("Player").GetComponent<MyKingdom>().MyCastle;
        Vector3 Pos = new Vector3(Castle.transform.position.x, Castle.transform.position.y - 1f, Castle.transform.position.z - 1f);
        Instantiate(Army, Pos, Quaternion.identity, GameObject.Find("World").GetComponent<Transform>());
    }

}
