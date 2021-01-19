using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
public class Economy : MonoBehaviour
{
    private StructEconomy PlayerEconomy;

    private float timer = 0;
    private int GoldIncome = 10;
    private int FoodIncome = 10;
    private int PeopleIncome = 10;


    //Инициализация экономики игрока, присовение стартовых ресурсов
    void Start()
    {
        //PlayerEconomy = GetComponent<StructEconomy.Struct>();
        PlayerEconomy = new StructEconomy();
        PlayerEconomy.Income(100, 100, 100);
        print("Hello World");
        print(PlayerEconomy.GetGold());
    }

    //Пока нету времени, подсчет экономики и таймер здесь.В дальнейшем вынести таймер для экономики.

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > 8)
        {
            UpdateIncome();
            PlayerEconomy.Income(GoldIncome, FoodIncome, PeopleIncome);
            timer = 0;
        }
    }

    public int GetGold()
    {
        return PlayerEconomy.GetGold();
    }

    public int GetFood()
    {
        return PlayerEconomy.GetFood();
    }

    public int GetPeople()
    {
        return PlayerEconomy.GetPeople();
    }

    public void UpdateIncome()
    {

    }
}
