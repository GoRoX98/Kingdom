using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructSoldire
{

    private string name;
    private float life;
    private float damage;
    private float speed;
    private float hireGold;
    private float weekFood;
    private float weekGold;

    public StructSoldire (string name, float life, float dmg, float speed, float HGold, float weekFood, float weekGold)
    {
        this.name = name;
        this.life = life;
        damage = dmg;
        this.speed = speed;
        hireGold = HGold;
        this.weekFood = weekFood;
        this.weekGold = weekGold;
    }

    public float[] GetParam()
    {
        float[] parametrs = new float[] {life, damage, weekFood, weekGold};
        return parametrs;
    }

    public float GetCost()
    {
        return hireGold;
    }
}
