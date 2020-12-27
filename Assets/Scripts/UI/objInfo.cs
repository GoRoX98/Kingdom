using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class objInfo : MonoBehaviour
{
    public GameObject pref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (Input.GetKeyDown(KeyCode.Mouse0))  OpenInfo();
        
    }

    public void OnMouseDown()
    {
        Console.WriteLine("Mouse1");
        Instantiate(pref);
    }
}
