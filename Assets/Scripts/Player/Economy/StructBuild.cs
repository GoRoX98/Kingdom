using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
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
    private float foodIncome;
    private float goldIncome;
    private float peopleIncome;
    private float life;
    private float PriceF;
    private float PriceG;
    private float PriceP;
    private int id;

    public StructBuild (string name, float food, float gold, float people, float life, float PriceF, float PriceG, float PriceP, int id)
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

    public float[] GetIncome()
    {
        float[] Income = new float[3] {foodIncome, goldIncome, peopleIncome};
        return Income;
    }

    public float[] GetCost()
    {
        float[] cost = new float[3] { PriceF, PriceG, PriceP };
        return cost;
    }
}

