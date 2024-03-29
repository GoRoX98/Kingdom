using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    [SerializeField]
    private float GameSpeed = 3.0f;
    private float day = 0.0f;
    private int week = 0;
    private int month = 3;
    // 1 - spring; 2 - summer; 3 - autumn; 4 - winter; 
    private int season = 1;
    //Triger about new week
    public bool NewWeek = false;
    /// <summary>
    /// World Time
    /// Every week income
    /// </summary>
    void FixedUpdate()
    {
        day += Time.deltaTime;
        NewWeek = false;

        if (day >= GameSpeed)
        {
            week += 1;
            day = 0.0f;
            NewWeek = true;
        }

        if (week == 4)
        {
            if (month < 11) month += 1;
            else month = 1;

            if (month >= 0 && month < 3) season = 0;
            if (month >= 3 && month < 6) season = 1;            
            if (month >= 6 && month < 9) season = 2;
            if (month >= 9 && month < 12) season = 3;

            week = 0;
            print($"Current month: {month} | Week: {week}");
        }

        
    }

    public int[] GetTime()
    {
        int[] WorldTime = new int[3] { week, month, season };
        return WorldTime;
    }
}
