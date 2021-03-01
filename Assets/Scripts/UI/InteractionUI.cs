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
        GameObject Region = GameObject.FindGameObjectWithTag("Region").GetComponent<Region>().Regions[IdRegion].GetRegion();
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
}
