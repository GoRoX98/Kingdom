using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructEconomy
{

    private int food;
    private int gold;
    private int people;


    public void Income(int GoldIncome, int FoodIncome, int PeopleIncome)
    {
        gold += GoldIncome;
        food += FoodIncome;
        people += PeopleIncome;
    }
    public int GetGold()
    {
        return gold;
    }
    public void SetGold(int GoldIncome)
    {
        gold += GoldIncome;
    }

    public int GetFood()
    {
        return food;
    }
    public void SetFood(int FoodIncome)
    {
        food += FoodIncome;
    }

    public int GetPeople()
    {
        return people;
    }
    public void SetPeople(int PeopleIncome)
    {
        people += PeopleIncome;
    }
}
