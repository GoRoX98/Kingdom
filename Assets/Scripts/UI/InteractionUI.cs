using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{


    public void Close()
    {
        print("Click");
        Destroy(gameObject);
    }

    public void Build()
    {
        
    }
}
