using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct StructBuild
{

    private int food;
    private int gold;
    private int people;
    private float life;
    private int PriceF;
    private int PriceG;
    private int PriceP;

    public StructBuild (int food, int gold, int people, float life, int PriceF, int PriceG, int PriceP)
    {
        this.food = food;
        this.gold = gold;
        this.people = people;
        this.life = life;
        this.PriceF = PriceF;
        this.PriceG = PriceG;
        this.PriceP = PriceP;
    }
}

