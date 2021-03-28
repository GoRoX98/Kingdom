using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{
    public enum UnitType
    {
        Messenger = 0,
        Advisor = 1,
        Army = 2
    }

    public UnitType Type;
    public UnitParametrs Parametrs;


    void Awake()
    {
        if (Type == UnitType.Advisor)
        {
            if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Architect) gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Capitan) gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Spy) gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

}
