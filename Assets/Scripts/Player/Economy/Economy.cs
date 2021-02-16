using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
public class Economy : MonoBehaviour
{
    public StructEconomy PlayerEconomy;
    private GameObject World;

    private int[] CurrentTime;
    private int TempWeek = 0;


    //Create player economy, starter recources, starter income
    void Start()
    {
        World = GameObject.Find("World");
        PlayerEconomy = new StructEconomy();
        PlayerEconomy.AddFood(100);
        PlayerEconomy.AddGold(100);
        PlayerEconomy.AddPeople(100);
        print("Hello World");
        print(PlayerEconomy.GetGold());
    }

    //Economy update

    void FixedUpdate()
    {
        CurrentTime = World.GetComponent<WorldTime>().GetTime();

        if (TempWeek != CurrentTime[0])
        {
            //Update player income
            PlayerEconomy.SetIncome(GetComponent<MyKingdom>().DomainIncome());
            //Call income function
            PlayerEconomy.Income();
            print($"Food: {PlayerEconomy.TakeIncome()[0]} | Gold: {PlayerEconomy.TakeIncome()[1]} | People: {PlayerEconomy.TakeIncome()[2]}");
            TempWeek = CurrentTime[0];
        }
    }

}
