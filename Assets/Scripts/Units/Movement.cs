using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool SelectUnit = false;
    public bool CurrentPlace = true;
    public float dist;

    private GameObject World;
    private GameObject Player;
    private Transform Position;
    private Animator Animator;

    private bool Moving = false;
    private Unit.UnitType Type;
    private int RegionId;

    void Awake()
    {
        Animator = GetComponent<Animator>();
        Position = GetComponent<Transform>();
        Player = GameObject.Find("Player");
        World = GameObject.Find("World");
    }

    void FixedUpdate()
    {
        if (Moving == true) Move();
    }

    /// <summary>
    /// Movement of unit
    /// </summary>
    public void Move()
    {
        //Deselect unit
        bool temp = Player.GetComponent<Action>().TrigerLMB;
        if (temp == true)
        {
            SelectUnit = false;
            Animator.SetBool("Select", SelectUnit);
        }
        //Process of movement v1.1
        if (CurrentPlace == false)
        {
            dist = World.GetComponent<WorldList>().Regions[RegionId].GetPosition().position.x - Position.position.x;
            
            if (dist >= 0.1f || dist <= -0.1f)  Animator.SetFloat("Distance", dist);
            else
            {
                CurrentPlace = true;
                Moving = false;
                dist = 0f;
                Animator.SetBool("Current Place", CurrentPlace);
                Animator.SetFloat("Distance", dist);
            }
        }
        //Process of movement 
            #region OldMove
            /*        if (CurrentPlace == false)
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
                    if (SelectUnit == true && Input.GetMouseButtonDown(1))
                    {
                        tempX = Player.GetComponent<Action>().CoordXY.x;
                        dist = tempX - (currentPos.x + Camera.main.orthographicSize);
                        if (dist >= 0.1f || dist <= -0.1f) CurrentPlace = false;
                        else CurrentPlace = true;
                    }*/
            #endregion
    }

    public void LetsMove(Unit.UnitType Type, int RegionId)
    {
        Moving = true;
        this.Type = Type;
        this.RegionId = RegionId;
        CurrentPlace = false;
    }

    public bool MoveStatus()
    {
        return Moving;
    }
}
