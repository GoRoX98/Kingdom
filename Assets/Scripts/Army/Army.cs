using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Army : MonoBehaviour
{
    public bool SelectArmy = false;
    public bool CurrentPlace = true;
    private Transform Position;
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
        Position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        SelectArmy = true;
        Animator.SetBool("Select", SelectArmy);
    }

    void FixedUpdate()
    {
        
    }
}
