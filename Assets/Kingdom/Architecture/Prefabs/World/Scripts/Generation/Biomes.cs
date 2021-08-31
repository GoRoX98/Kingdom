[System.Serializable]
public struct Biomes
{

    public string Name;
    public string Description;
    public float Speed;
    public float BuildingCostMod;
    public float BuildingSpeedMod;
    public float StealthMod;
    public float AmbushMod;


    public Biomes(string Name, string Description, float Speed, float BuildingCostMod, float BuildingSpeedMod, float StealthMod, float AmbushMod)
    {
        this.Name = Name;
        this.Description = Description;
        this.Speed = Speed;
        this.BuildingCostMod = BuildingCostMod;
        this.BuildingSpeedMod = BuildingSpeedMod;
        this.StealthMod = StealthMod;
        this.AmbushMod = AmbushMod;
    }

}
