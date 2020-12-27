using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 1.0f;
    private Transform playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) playerCamera.transform.position = new Vector2(playerCamera.position.x - speed, playerCamera.position.y);
        if (Input.GetKey(KeyCode.D)) playerCamera.transform.position = new Vector2(playerCamera.position.x + speed, playerCamera.position.y);
    }
}
