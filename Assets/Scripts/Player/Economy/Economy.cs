using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
public class Economy : MonoBehaviour
{
    private StructEconomy PlayerEconomy;
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

    /// <summary>
    /// 
    /// </summary>
    /// <returns>How many gold player have</returns>
    public int GetGold()
    {
        return PlayerEconomy.GetGold();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>How many food player have</returns>
    public int GetFood()
    {
        return PlayerEconomy.GetFood();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>How many people player have</returns>
    public int GetPeople()
    {
        return PlayerEconomy.GetPeople();
    }

}
