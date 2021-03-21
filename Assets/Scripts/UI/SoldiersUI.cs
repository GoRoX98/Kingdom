using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldiersUI : MonoBehaviour
{
    public List<Text> MyArmy;

    private GameObject Player;

    void Awake()
    {
        Player = GameObject.Find("Player");
    }


    void FixedUpdate()
    {
        int[] Soldires = Player.GetComponent<MyKingdom>().AllSoldires();
        for (int i = 0; Soldires.Length > i; i++)
        {
            MyArmy[i].text = Soldires[i].ToString();
        }
    }
}
