using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructArmy
{

    private string ArmyName;
    private int People;
    private int[] ArmyStruct;
    private float SumLife;
    private float SumDmg;
    private float SumGold;
    private float SumFood;

    public StructArmy(string name, int[] ArmyStructure, float SumLife, float SumDmg, float SumGold, float SumFood)
    {
        ArmyName = name;
        ArmyStruct = ArmyStructure;
        int People = 0;
        for (int i = 0; ArmyStructure.Length < i; i++)
        {
            People += ArmyStructure[i];
        }
        this.People = People;
        this.SumLife = SumLife;
        this.SumDmg = SumDmg;
        this.SumFood = SumFood;
        this.SumGold = SumGold;
    }
    

}
