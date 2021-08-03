using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StructRegion
{
    private int RegionId;
    private string RegionName;
    private int Biome;
    private Transform Position;
    // 0 - neutral; 1 - player; 2 - AI or 2 Player
    private int Owner;
    private GameObject Region;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="RegionId">Id of region</param>
    /// <param name="RegionName">Name of region</param>
    /// <param name="Biome">Biome (WIP)</param>
    /// <param name="Position">Transform of region</param>
    /// <param name="Owner">Which region</param>
    /// <param name="Region">GameObject of Region</param>
    public StructRegion(int RegionId, string RegionName, int Biome, Transform Position, int Owner, GameObject Region)
    {
        this.RegionId = RegionId;
        this.RegionName = RegionName;
        this.Biome = Biome;
        this.Position = Position;
        this.Owner = Owner;
        this.Region = Region;
    }

    public string PrintInfo()
    {
        string info = $"Id = {RegionId}, Name = {RegionName}, Id Biome = {Biome}, Transform = {Position}, Owner = {Owner}";
        return info;
    }

    /// <summary>
    /// Data of this region - string[] (WIP)
    /// </summary>
    /// <returns>Name, Id, Owner</returns>
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

    public GameObject GetRegion()
    {
        return Region;
    }
}
