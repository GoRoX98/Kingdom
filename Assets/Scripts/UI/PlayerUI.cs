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

    public Text GoldUI;
    public Text FoodUI;
    public Text PeopleUI;



    void Start()
    {
        resText();
        Clock();
    }

    
    void Update()
    {
        resText();
        Clock();
    }

    public void resText()
    {
        int gold = Player.GetComponent<Economy>().PlayerEconomy.GetGold();
        int food = Player.GetComponent<Economy>().PlayerEconomy.GetFood();
        int people = Player.GetComponent<Economy>().PlayerEconomy.GetPeople();
        GoldUI.text = $"Gold: {gold}";
        FoodUI.text = $"Food: {food}";
        PeopleUI.text = $"People: {people}";
    }

    public void Clock()
    {
        CurrentTime = World.GetComponent<WorldTime>().GetTime();
        Oclock.GetComponent<ListUI>().Clock[0].text = $"Week: {CurrentTime[0]}";
        Oclock.GetComponent<ListUI>().Clock[1].text = World.GetComponent<WorldList>().Month[CurrentTime[1]];
        Oclock.GetComponent<ListUI>().Clock[2].text = World.GetComponent<WorldList>().Season[CurrentTime[2]];
    }
}
