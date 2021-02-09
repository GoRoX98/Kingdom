using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct StructBuild
{
    /// <summary>
    /// 1-3 - income
    /// 4 - life
    /// 5-7 - cost
    /// 8 - id of building
    /// </summary>
    private int food;
    private int gold;
    private int people;
    private float life;
    private int PriceF;
    private int PriceG;
    private int PriceP;
    private int id;

    public StructBuild (int food, int gold, int people, float life, int PriceF, int PriceG, int PriceP, int id)
    {
        this.food = food;
        this.gold = gold;
        this.people = people;
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
        int[] Income = new int[3] {food, gold, people};
        return Income;
    }
}

