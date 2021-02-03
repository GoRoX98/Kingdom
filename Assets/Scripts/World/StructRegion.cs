using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructRegion
{
    private int RegionId;
    private string RegionName;
    private int Biome;
    private Transform Position;
    // 0 - neutral; 1 - player; 2 - AI or 2 Player
    private int Owner;
    
    public StructRegion(int RegionId, string RegionName, int Biome, Transform Position, int Owner)
    {
        this.RegionId = RegionId;
        this.RegionName = RegionName;
        this.Biome = Biome;
        this.Position = Position;
        this.Owner = Owner;
    }

    public string PrintInfo()
    {
        string info = $"Id = {RegionId}, Name = {RegionName}, Id Biome = {Biome}, Transform = {Position}, Owner = {Owner}";
        return info;
    }

    public string[] Data()
    {
        string[] Data = new string[3] {RegionName, $"ID: {RegionId.ToString()}", $"Owner: {Owner.ToString()}"};
        return Data;
    }

    public int InfoOwner()
    {
        return Owner;
    }

    public Transform GetPosition()
    {
        return Position;
    }
}
