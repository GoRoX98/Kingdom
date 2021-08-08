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
    /// Hire function. Rewrite it!!!
    /// </summary>
    /// <param name="Amount">How many soldiers of this type wonna hire</param>
    /// <param name="Who">Type of soldire</param>
    public void HireSoldires()
    {
        Type = gameObject.GetComponent<InteractionUI>().Parametrs.Integer[0];
        int amount = int.Parse(Amount.text);
        print(amount);
        Soldiers Soldire = World.GetComponent<WorldList>().Resources.Soldiers[Type];
        StructEconomy Economy = Player.GetComponent<Economy>().PlayerEconomy;
        float SumGold = amount * Soldire.HireGold;
        int[] add = new int[World.GetComponent<WorldList>().Resources.Soldiers.Count];

        if (Economy.GetResources()[1] >= SumGold)
        {
            for (int i = 0; add.Length > i; i++)
            {
                if (i == Type) add[i] = amount;
                else add[i] = 0;
            }
            float[] spend = new float[] { 0, SumGold, 0 };
            Player.GetComponent<Economy>().PlayerEconomy.Spend(spend);
            Player.GetComponent<MyKingdom>().AddSoldires(add);
            print("Hire sucsess");
        }
        else print("Not enough gold");
    }
}
