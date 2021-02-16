using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Structure of Player economy
/// </summary>
public struct StructEconomy
{

    private int food;
    private int gold;
    private int people;

    private int foodIncome;
    private int goldIncome;
    private int peopleIncome;

    /// <summary>
    /// Function for update amount of player
    /// </summary>
    public void Income()
    {
        gold += goldIncome;
        food += foodIncome;
        people += peopleIncome;
    }

    /// <summary>
    /// Set weekly income
    /// </summary>
    /// <param name="Income">Food, Gold, People</param>
    public void SetIncome(int[] Income)
    {
        foodIncome = Income[0];
        goldIncome = Income[1];
        peopleIncome = Income[2];
    }

    /// <summary>
    /// Take info about player income
    /// </summary>
    /// <returns>Food, Gold, People</returns>
    public int[] TakeIncome()
    {
        int[] Income = new int[3] { foodIncome, goldIncome, peopleIncome };
        return Income;
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

    /// <summary>
    /// Spend player's res for something 
    /// </summary>
    /// <param name="Res">Food, Gold, People</param>
    public void Spend(int[] Res)
    {
        food -= Res[0];
        gold -= Res[1];
        people -= Res[2];
    }
}
