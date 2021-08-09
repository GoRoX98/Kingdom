using UnityEngine;
using UnityEngine.UI;

public class Hire : MonoBehaviour
{
    public GameObject World;
    public GameObject Player;
    public Text Amount;
    public int Type;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        World = GameObject.Find("World");
    }

    /// <summary>
    /// Hire function.
    /// TODO: В данный момент не тратятся люди.
    /// </summary>
    /// <param name="Amount">How many soldiers of this type wonna hire</param>
    /// <param name="Who">Type of soldire</param>
    public void HireSoldires()
    {
        int amount = int.Parse(Amount.text);
        Soldiers Soldire = World.GetComponent<WorldList>().Resources.Soldiers[Type];
        StructEconomy Economy = Player.GetComponent<Economy>().PlayerEconomy;
        float SumGold = amount * Soldire.HireGold;
        float SumFood = amount * Soldire.HireFood;
        int[] add = new int[World.GetComponent<WorldList>().Resources.Soldiers.Count];

        if (Economy.GetResources()[1] >= SumGold && Economy.GetResources()[0] >= SumFood)
        {
            for (int i = 0; add.Length > i; i++)
            {
                if (i == Type) add[i] = amount;
                else add[i] = 0;
            }
            float[] spend = new float[] { SumFood, SumGold, 0 };
            Player.GetComponent<Economy>().PlayerEconomy.Spend(spend);
            Player.GetComponent<MyKingdom>().AddSoldires(add);
            Amount.text = "00";
            print("Hire sucsess");
        }
        else if (Economy.GetResources()[1] < SumGold) print("Not enough gold");
        else if (Economy.GetResources()[1] < SumFood) print("Not enough food");
        else print("Process of Hire dont work?");
    }

    public void More()
    {
        int newAmount = int.Parse(Amount.text) + 10;
        Amount.text = newAmount.ToString();
    }

    public void Less()
    {
        int newAmount = int.Parse(Amount.text);
        if (newAmount > 0) newAmount = newAmount - 10;
        Amount.text = newAmount.ToString();
    }
}
