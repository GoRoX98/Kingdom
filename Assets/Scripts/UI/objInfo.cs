using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class objInfo : MonoBehaviour
{
    public GameObject pref;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))    this.gameObject.GetComponent<Region>().InfoRegion();
    }

    public void OnMouseDown()
    {
        Instantiate(pref);
    }


}
