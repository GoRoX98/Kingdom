using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructRegion
{
    private int RegionId;
    private string RegionName;
    private int Biome;
    private float[] CoordinateRegion;
    
    public StructRegion(int RegionId, string RegionName, int Biome, float[] CoordinateRegion)
    {
        this.RegionId = RegionId;
        this.RegionName = RegionName;
        this.Biome = Biome;
        this.CoordinateRegion = CoordinateRegion;
    }

}
