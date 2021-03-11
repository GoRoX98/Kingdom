using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hire : MonoBehaviour
{
    public GameObject World;
    public GameObject Player;
    public Text Amount;
    public int Type;

    /// <summary>
    /// Hire function
    /// </summary>
    /// <param name="Amount">How many soldiers of this type wonna hire</param>
    /// <param name="Who">Type of soldire</param>
    public void HireSoldires()
    {
        int amount = int.Parse(Amount.text);
        print(amount);
        StructSoldire TypeSoldire = World.GetComponent<WorldList>().SoldiresType[Type];
        StructEconomy Economy = Player.GetComponent<Economy>().PlayerEconomy;
        float SumGold = amount * TypeSoldire.GetCost();
        int[] add = new int[3];

        if (Economy.GetResources()[1] >= SumGold)
        {
            for (int i = 0; add.Length > i; i++)
            {
                if (i == Type) add[i] = amount;
                else add[i] = 0;
            }
            Player.GetComponent<MyKingdom>().AddSoldires(add);
        }
        else print("Not enough gold");
    }
}
