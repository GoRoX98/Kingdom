using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    
    private int[] CurrentTime;
    public GameObject Oclock;
    public GameObject World;
    public GameObject Player;

    public List<Text> MyArmy;
    public List<Text> ResourcesUI;
    public List<GameObject> PrefsUI;



    void Start()
    {
        resText();
        Clock();
    }

    
    void Update()
    {
        resText();
        Clock();
        MyArmy[0].text = Player.GetComponent<MyKingdom>().SumSoldires().ToString();
    }

    public void resText()
    {
        float[] res = Player.GetComponent<Economy>().PlayerEconomy.GetResources();
        float[] income = Player.GetComponent<Economy>().PlayerEconomy.GetIncome();
        ResourcesUI[0].text = $"Food: {res[0]}";
        ResourcesUI[1].text = $"Gold: {res[1]}";
        ResourcesUI[2].text = $"People: {res[2]}";

        for (int i = 0; i < 3; i++)
        {
            if (income[i] >= 0)
            {
                ResourcesUI[i + 3].text = $"+ {income[i]}";
                ResourcesUI[i+3].color = new Color32(14, 185, 0, 255);
            }
            else
            {
                ResourcesUI[i + 3].text = $"- {income[i]}";
                ResourcesUI[i + 3].color = new Color32(185, 0, 9, 255);
            }
        }
    }

    public void Clock()
    {
        CurrentTime = World.GetComponent<WorldTime>().GetTime();
        Oclock.GetComponent<ListUI>().Clock[0].text = $"Week: {CurrentTime[0]}";
        Oclock.GetComponent<ListUI>().Clock[1].text = World.GetComponent<WorldList>().Month[CurrentTime[1]];
        Oclock.GetComponent<ListUI>().Clock[2].text = World.GetComponent<WorldList>().Season[CurrentTime[2]];
    }
}
