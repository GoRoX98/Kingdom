using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Economy : MonoBehaviour
{
    
   

    private float timer = 0;
    private int GoldIncome = 10;
    private int FoodIncome = 10;
    private int PeopleIncome = 10;


    //Инициализация экономики игрока, присовение стартовых ресурсов
    void Start()
    {
        GameObject go = new GameObject();
        go.AddComponent<StructE>();
        StructE.Struct PlayerEconomy = go.GetComponent<StructE.Struct>();
        PlayerEconomy.Income(100, 100, 100);
    }

    // Пока нету времени, подсчет экономики и таймер здесь. В дальнейшем вынести таймер для экономики.
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > 8) PlayerEconomy.Income(GoldIncome, FoodIncome, PeopleIncome);
    }

    public int GetGold()
    {
        return PlayerEconomy.GetGold();
    }


}
