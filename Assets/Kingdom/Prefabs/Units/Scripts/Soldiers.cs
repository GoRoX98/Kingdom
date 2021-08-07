using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Soldiers
{
    public string Name;
    public float Damage;
    public float Deffense;
    public float Speed;
    public float Morale;
    public float HireGold;
    public float HireFood;
    public float HireTime;

    public Soldiers(string Name, float Damage, float Deffense, float Speed, float Morale, float HireGold, float HireFood, float HireTime)
    {
        this.Name = Name;
        this.Damage = Damage;
        this.Deffense = Deffense;
        this.Speed = Speed;
        this.Morale = Morale;
        this.HireGold = HireGold;
        this.HireFood = HireFood;
        this.HireTime = HireTime;
    }
/*        public float[] GetParam()
    {
        float[] parametrs = new float[] { Deffense, Damage };
        return parametrs;
    }*/
 
}
