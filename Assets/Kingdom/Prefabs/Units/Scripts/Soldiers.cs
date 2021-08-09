[System.Serializable]
public struct Soldiers
{
    public string Name;
    public float HireGold;
    public float HireFood;
    public float Damage;
    public float Deffense;
    public float Morale;
    public float Speed;
    public float HireTime;

    public Soldiers(string Name, float Damage, float Deffense, float Speed, float Morale, float HireGold, float HireFood, float HireTime)
    {
        this.Name = Name;
        this.Damage = Damage;
        this.Deffense = Deffense;
        this.Speed = Speed;
        this.Morale = Morale;
        this.HireGold = HireGold;
        this.HireFood = HireFood;
        this.HireTime = HireTime;
    }
/*        public float[] GetParam()
    {
        float[] parametrs = new float[] { Deffense, Damage };
        return parametrs;
    }*/

    public string TakeText(int i)
    {
        string[] Data = new string[] { Name, "Gold: " + HireGold.ToString(), "Food: " + HireFood.ToString(), "Damage: " + Damage.ToString(), "Deffense: " + Deffense.ToString(), "Morale: " + Morale.ToString(), "Speed: " + Speed.ToString(), "Hire Time: " + HireTime.ToString() };
        return Data[i];
    }
}
