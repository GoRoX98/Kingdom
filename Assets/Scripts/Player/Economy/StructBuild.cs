using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct StructBuild
{
    /// <summary>
    /// 1-3 - ����� ������
    /// 4 - �����
    /// 5-7 - ��������� ���������
    /// 8 - �������� (0 - �����������, 1 - ����� 1, 2 - ����� 2)
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

