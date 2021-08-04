using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Soldiers
{
    public string Name;
    public float Damage;
    public float Deffense;
    public float Speed;
    public float HireGold;
    public float HireFood;
    public float HireTime;
    //WIP (Legacy) - now without cost per week
/*    public float WeekFood;
    public float WeekGold;*/

    public float[] GetParam()
    {
        float[] parametrs = new float[] { Deffense, Damage};
        return parametrs;
    }
}
