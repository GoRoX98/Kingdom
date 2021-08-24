using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GeneratorParametrs
{
    public bool PVP;
    [Range(0f, 100f)]
    public float _Chance;
    public List<float> biomeChance;

    
}
