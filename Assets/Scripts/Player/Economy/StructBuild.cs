using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct StructBuild
{
    /// <summary>
    /// 1-3 - инкам здания
    /// 4 - жизни
    /// 5-7 - стоимость постройки
    /// 8 - владелец (0 - нейтральное, 1 - игрок 1, 2 - игрок 2)
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
}

