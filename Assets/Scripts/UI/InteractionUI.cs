using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    private GameObject MyKingdom;
    public GameObject Child;
    public GameObject Parent;

    public Parametrs Parametrs = new Parametrs();
    public bool UseParametrs = false;


    void Awake()
    {
        MyKingdom = GameObject.FindGameObjectWithTag("Player");
    }  
    

    public void Close()
    {
        print("Click Close");
        Destroy(gameObject);
    }

    public void Build(int IdBuilding)
    {
        int IdRegion = Convert.ToInt32(GameObject.Find("Canvas Region").GetComponent<ListUI>().Id);
        GameObject Region = GameObject.Find("World").GetComponent<WorldList>().Regions[IdRegion].GetRegion();
        print($"Region {IdRegion} Build {IdBuilding}");
        MyKingdom.GetComponent<Build>().NewBuild(IdRegion, IdBuilding, Region);
        
    }

    public void ActivateObj (GameObject Obj)
    {
        Debug.Log("Activate");
        Obj.SetActive(true);
    }

    public void DisactivateObj(GameObject Obj)
    {
        Debug.Log("Disactivate");
        Obj.SetActive(false);
    }

    public void OpenWindow()
    {
        if (UseParametrs == true)
        {
            Child.GetComponent<InteractionUI>().Parametrs = Parametrs;
        }

        if (Parent == null)     Instantiate(Child);
        else    Instantiate(Child, Parent.transform);
    }
}
