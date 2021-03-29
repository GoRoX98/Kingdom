using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Prototype of generation parametrs for regions on the scene
/// </summary>
public class Region : MonoBehaviour
{
    [SerializeField]
    public StructRegion ThisRegion;
    [SerializeField]
    //Id of Regions. Costil for using in others scripts
    private int RegionId;
    //List of buildings in this region

    [SerializeField] public List<StructBuild> Buildings = new List<StructBuild>();

    public int GetId()
    {
        return RegionId;
    }

    public void SetId(int Id)
    {
        RegionId = Id;
    }

    public void SetStruct(StructRegion Region)
    {
        ThisRegion = Region;
    }
}