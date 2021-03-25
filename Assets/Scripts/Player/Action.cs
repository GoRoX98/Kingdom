using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Action : MonoBehaviour
{

    public bool TrigerLMB;
    public Vector2 CoordXY;

    void Start()
    {
        TrigerLMB = false;
    }

    void FixedUpdate()
    {
        TrigerLMB = false;
        if (Input.GetMouseButtonDown(1))
        {
            CoordXY = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CoordXY.x += Camera.main.orthographicSize;
            print($"Coordinate: {CoordXY}");
        }
        if (Input.GetMouseButtonDown(0))
        {
            TrigerLMB = true;
            print("LBM");
        }
    }

}
