using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy : MonoBehaviour
{

    private int food = 100;
    private int gold = 100;
    private int people = 100;
    private float timer = 0;




    // Пока нету времени, подсчет экономики и таймер здесь. В дальнейшем вынести таймер для экономики.
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > 8) PlayerEconomy();
    }

    private void PlayerEconomy()
    {
        food += 10;
        gold += 10;
        people += 10;
    }

    public int GetFood()
    {
        return this.food;
    }

    public int GetGold()
    {
        return this.gold;
    }
    public int GetPeople()
    {
        return this.people;
    }
}
