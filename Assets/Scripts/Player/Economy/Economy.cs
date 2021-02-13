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
    private int GoldIncome = 10;
    private int FoodIncome = 10;
    private int PeopleIncome = 10;


    //Create player economy, starter recources, starter income
    void Start()
    {
        World = GameObject.Find("World");
        PlayerEconomy = new StructEconomy();
        PlayerEconomy.AddFood(100);
        PlayerEconomy.AddGold(100);
        PlayerEconomy.AddPeople(100);
        PlayerEconomy.SetIncome(FoodIncome, GoldIncome, PeopleIncome);
        print("Hello World");
        print(PlayerEconomy.GetGold());
    }

    //Economy update

    void FixedUpdate()
    {
        CurrentTime = World.GetComponent<WorldTime>().GetTime();

        if (TempWeek != CurrentTime[0])
        {
            PlayerEconomy.Income();
            TempWeek = CurrentTime[0];
        }
    }

}
