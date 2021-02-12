using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    Economy PlayerEconomy;
    private int[] CurrentTime;
    public GameObject Oclock;
    public GameObject World;

    public Text GoldUI;
    public Text FoodUI;
    public Text PeopleUI;



    void Start()
    {
        PlayerEconomy = GameObject.Find("Player").GetComponent<Economy>();
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
        int gold = PlayerEconomy.GetGold();
        int food = PlayerEconomy.GetFood();
        int people = PlayerEconomy.GetPeople();
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
