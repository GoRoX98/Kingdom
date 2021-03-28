using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool SelectArmy = false;
    public bool CurrentPlace = true;
    public float dist;

    private GameObject World;
    private GameObject Player;
    private Transform Position;
    private Animator Animator;

    private Vector2 currentPos;
    private float tempX;

    void Awake()
    {
        Animator = GetComponent<Animator>();
        Position = GetComponent<Transform>();
        Player = GameObject.Find("Player");
        World = GameObject.Find("World");
    }

    //Select unit
    void OnMouseDown()
    {
        SelectArmy = true;
        Animator.SetBool("Select", SelectArmy);
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Movement of unit
    /// </summary>
    private void Move()
    {
        //Deselect unit
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
    }
}
