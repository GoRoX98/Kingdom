using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldiersList : MonoBehaviour
{
    public GameObject Prefab;
    private GameObject World;
    private List<Soldiers> SoldiersDB;

    private void Start()
    {
        World = GameObject.Find("World");
        SoldiersDB = World.GetComponent<WorldList>().Resources.Soldiers;
        generateList();
    }

    //TODO: —тоит искусственное ограничение на генерацию не более 5, в дальнейшем можно убрать, сейчас скорее всего будут ошибки, если делать больше 5.
    private void generateList()
    {
        for (int i = 0; i < SoldiersDB.Count && i < 5; i++)
        {
            GameObject SoldierGO = Instantiate(Prefab, gameObject.transform);
            SoldierGO.GetComponent<ListUI>().TextFields = SetText(SoldierGO, i);
            SoldierGO.transform.Find("Hire").Find("Hire Button").GetComponent<Hire>().Type = i;
        }
    }

    private List<Text> SetText(GameObject SoldierGO, int b)
    {
        List<Text> Fields = SoldierGO.GetComponent<ListUI>().TextFields;
        for (int i = 0; i<Fields.Count; i++)
        {
            Fields[i].text = SoldiersDB[b].TakeText(i);
        }
        return Fields;
    }
}
