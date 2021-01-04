using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    Economy PlayerEconomy;
    public Text GoldUI;
    public Text FoodUI;
    public Text PeopleUI;



    void Start()
    {
        PlayerEconomy = GameObject.Find("Player").GetComponent<Economy>();
    }

    
    void Update()
    {
        resText();
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
}
