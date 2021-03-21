using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateArmy : MonoBehaviour
{
    public GameObject World;
    public GameObject Player;

    public List<Text> fields;
    private Scrollbar[] sliders;
    private int[] amount;
    private int[] HowMany;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        World = GameObject.Find("World");
        amount = Player.GetComponent<MyKingdom>().AllSoldires();
        sliders = GameObject.FindObjectsOfType<Scrollbar>();
        HowMany = new int[amount.Length];
    }

    void FixedUpdate()
    {
        for (int i = 0; sliders.Length > i; i++)
        {
            if (sliders[i].value * 100 > 0) HowMany[i] =  amount[i] / 100 * Convert.ToInt32(sliders[i].value * 100);
            else if (Convert.ToInt32(sliders[i].value * 100) > amount[i])
            {
                HowMany[i] = amount[i];
            }

            fields[i].text = HowMany[i].ToString();
        }
    }


    public void HireArmy(GameObject Army)
    {

        GameObject Castle = GameObject.Find("Castle");
        Vector3 Pos = new Vector3(Castle.transform.position.x, Castle.transform.position.y - 1f, Castle.transform.position.z - 1f);
        Instantiate(Army, Pos, Quaternion.identity, GameObject.Find("World").GetComponent<Transform>());
    }

}
