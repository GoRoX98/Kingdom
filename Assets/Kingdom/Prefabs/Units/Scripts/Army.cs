using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Army : MonoBehaviour
{public StructArmy ArmyStructure = new StructArmy();

    private GameObject World;

    void Awake()
    {
        World = GameObject.Find("World");
        ArmyStructure.Soldires = GameObject.Find("World").GetComponent<WorldList>().SoldiresDB;
    }


    void FixedUpdate()
    {
        if (World.GetComponent<WorldTime>().NewWeek == true) ArmyStruct();
    }

/*    /// <summary>
    /// Movement of army
    /// </summary>
    private void ArmyMovement()
    {
        //Deselect army
        bool temp = Player.GetComponent<Action>().TrigerLMB;
        currentPos = Position.position;
        if (temp == true)
        {
            SelectArmy = false;
            Animator.SetBool("Select", SelectArmy);
        }
        //Process of movement 
        if (CurrentPlace == false)
        {
            dist = tempX - (currentPos.x + Camera.main.orthographicSize);
            if (dist >= 0.1f || dist <= -0.1f)
            {
                CurrentPlace = false;
                Animator.SetBool("Current Place", CurrentPlace);
                Animator.SetFloat("Distance", dist);
            }
            else
            {
                CurrentPlace = true;
                dist = 0f;
                Animator.SetBool("Current Place", CurrentPlace);
                Animator.SetFloat("Distance", dist);
            }
        }
        //Move where (position)
        if (SelectArmy == true && Input.GetMouseButtonDown(1))
        {
            tempX = Player.GetComponent<Action>().CoordXY.x;
            dist = tempX - (currentPos.x + Camera.main.orthographicSize);
            if (dist >= 0.1f || dist <= -0.1f) CurrentPlace = false;
            else CurrentPlace = true;
        }
    }*/

    private void ArmyStruct()
    {
        ArmyStructure.People = 0;
        ArmyStructure.SumDmg = 0;
        ArmyStructure.SumFood = 0;
        ArmyStructure.SumGold = 0;
        ArmyStructure.SumLife = 0;
        print("ArmyStruct");
        for (int i = 0; ArmyStructure.Soldires.Count > i; i++)
        {
            ArmyStructure.People += ArmyStructure.ArmyStruct[i];
            ArmyStructure.SumDmg += ArmyStructure.ArmyStruct[i] * ArmyStructure.Soldires[i].Damage;
            ArmyStructure.SumLife += ArmyStructure.ArmyStruct[i] * ArmyStructure.Soldires[i].Deffense;
        }
    }
}
