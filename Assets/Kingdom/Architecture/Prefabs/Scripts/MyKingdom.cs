using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKingdom : MonoBehaviour
{
    private GameObject World;
    private int PlayerId;


    public List<GameObject> MyDomain;
    //Castle of Player
    public GameObject MyCastle;
    //Amount of regions on the Map
    private int Amount;
    //Amount of regions of player kingdome
    private int MyAmount;
    //WIP - this for future, when player lose some regions and need del them from his MyDomain
    private int TempMyAmount = 0;
    private GameObject[] Regions;
    private int TempMonth;

    [SerializeField]
    private List<GameObject> MyUnits;
    //Army
    private List<Soldiers> SoldiresTypes;
    private int[] AmountOfSoldires;
    private int[] SoldiersInArmy;

    private void Awake()
    {
        if (gameObject.name == "AI") PlayerId = 0;
        else PlayerId = 1;
    }

    void Start()
    {
        World = GameObject.Find("World");
        Regions = World.GetComponent<World>().Regions;
        Amount = Regions.Length;
        TempMonth = World.GetComponent<WorldTime>().GetTime()[1];

        SoldiresTypes = World.GetComponent<WorldList>().SoldiresDB;
        AmountOfSoldires = new int[SoldiresTypes.Count];
        for (int i = 0; SoldiresTypes.Count > i; i++)
        {
            AmountOfSoldires[i] = 0;
        }

        MyTerritory();
    }

    void FixedUpdate()
    {
        
        if (TempMonth != World.GetComponent<WorldTime>().GetTime()[1])
        {
            MyTerritory();
            TempMonth = World.GetComponent<WorldTime>().GetTime()[1];
        }
    }

    /// <summary>
    /// Check territory of player's kingdome
    /// </summary>
    private void MyTerritory()
    {
        MyAmount = 0;
        for (int i = 0; i < Amount; i++)
        {
            if (World.GetComponent<Generation>().Regions[i].InfoOwner() == 1 && PlayerId == 1)
            {
                MyAmount++;
                if (MyDomain.Count < MyAmount) MyDomain.Add(Regions[i]);
            }
        }
        if (TempMyAmount > MyAmount)
        {
            MyDomain.RemoveAt(TempMyAmount);
            TempMyAmount--;
        }
        TempMyAmount = MyAmount;
        
    }

    /// <summary>
    /// Income from player's kingdome
    /// </summary>
    /// <returns>Food, Gold, People</returns>
    public float[] DomainIncome()
    {
        //food, gold, people
        float[] Income = new float[3] {10, 10, 10};

        for (int i = 0; i < MyDomain.Count; i++)
        {
            List<StructBuild> Buildings = MyDomain[i].GetComponent<Region>().Buildings;
            for (int b = 0; b < Buildings.Count; b++)
            {
                Income[0] += Buildings[b].GetIncome()[0];
                Income[1] += Buildings[b].GetIncome()[1];
                Income[2] += Buildings[b].GetIncome()[2];
            }
        }

        return Income;
    }

    #region Army
    public void AddSoldires(int[] add)
    {
        for (int i = 0; AmountOfSoldires.Length > i; i++)
        {
            AmountOfSoldires[i] += add[i];
        }
    }

    public bool GetSoldires(int[] get)
    {
        bool verify = false;
        for (int i = 0; AmountOfSoldires.Length > i; i++)
        {
            if (AmountOfSoldires[i] > get[i])
            {
                verify = true;
            }
            else 
            {
                verify = false;
                break;
            }
        }
        if (verify == true)
        {
            for (int i = 0; AmountOfSoldires.Length > i; i++)
            {
                AmountOfSoldires[i] -= get[i];
            }
            return verify;
        }
        else
        {
            print("not enough soldires");
            return verify;
        }
    }

    
    public int[] AllSoldires()
    {
        return AmountOfSoldires;
    }

    public void UpdArmySoldires(int[] SoldiersInArmy)
    {
        this.SoldiersInArmy = SoldiersInArmy;
    }

    public int[] ArmySoldires()
    {
        return SoldiersInArmy;
    }

    public int SumSoldires()
    {
        int Sum = 0;
        for (int i = 0; AmountOfSoldires.Length > i; i++)
        {
            Sum += AmountOfSoldires[i];
        }
        return Sum;
    }
    #endregion

    #region UnitList
    public void AddUnit(GameObject NewUnit)
    {
        MyUnits.Add(NewUnit);
    }

    public List<GameObject> GetUnit()
    {
        return MyUnits;
    }

    public void DelUnit(int i)
    {
        MyUnits.RemoveAt(i);
    }
    #endregion
}
