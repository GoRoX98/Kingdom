using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct StructBuild
{
    /// <summary>
    /// 0 - Name
    /// 1-3 - income
    /// 4 - life
    /// 5-7 - cost
    /// 8 - id of building
    /// </summary>
    private string name;
    private int foodIncome;
    private int goldIncome;
    private int peopleIncome;
    private float life;
    private int PriceF;
    private int PriceG;
    private int PriceP;
    private int id;

    public StructBuild (string name, int food, int gold, int people, float life, int PriceF, int PriceG, int PriceP, int id)
    {
        this.name = name;
        this.foodIncome = food;
        this.goldIncome = gold;
        this.peopleIncome = people;
        this.life = life;
        this.PriceF = PriceF;
        this.PriceG = PriceG;
        this.PriceP = PriceP;
        this.id = id;
    }

    public int GetId()
    {
        return id;
    }

    public int[] GetIncome()
    {
        int[] Income = new int[3] {foodIncome, goldIncome, peopleIncome};
        return Income;
    }

    public int[] GetCost()
    {
        int[] cost = new int[3] { PriceF, PriceG, PriceP };
        return cost;
    }
}

