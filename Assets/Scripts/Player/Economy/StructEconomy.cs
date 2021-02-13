using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructEconomy
{

    private int food;
    private int gold;
    private int people;

    private int foodIncome;
    private int goldIncome;
    private int peopleIncome;


    public void Income()
    {
        gold += goldIncome;
        food += foodIncome;
        people += peopleIncome;
    }

    public void SetIncome(int Food, int Gold, int People)
    {
        foodIncome = Food;
        goldIncome = Gold;
        peopleIncome = People;
    }

    public int GetGold()
    {
        return gold;
    }
    public void AddGold(int GoldIncome)
    {
        gold += GoldIncome;
    }

    public int GetFood()
    {
        return food;
    }
    public void AddFood(int FoodIncome)
    {
        food += FoodIncome;
    }

    public int GetPeople()
    {
        return people;
    }
    public void AddPeople(int PeopleIncome)
    {
        people += PeopleIncome;
    }

    /// <summary>
    /// Get info about player res
    /// </summary>
    /// <returns>info of player res</returns>
    public int[] GetResources()
    {
        int[] Resources = new int[3] {food, gold, people};
        return Resources;
    }

    public void Spend(int[] Res)
    {
        food -= Res[0];
        gold -= Res[1];
        people -= Res[2];
    }
}
