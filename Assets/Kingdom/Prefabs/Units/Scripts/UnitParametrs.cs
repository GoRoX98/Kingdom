using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitParametrs
{
    //General param
    public string Name;
    public float SpeedMap;
    public List<Sprite> Sprites;
    
    //adviser
    public enum AdviserType
    {
       None = 0,
       Architect = 1,
       Spy = 2,
       Capitan = 3
    }
    public AdviserType TypeOfAdviser;
    public float WorkSpeed;
    public float Victims;

    //messenger
    public float Endurance;
}
