using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class objInfo : MonoBehaviour
{
    public GameObject pref;

    public void OnMouseDown()
    {
        Instantiate(pref);
    }
}
