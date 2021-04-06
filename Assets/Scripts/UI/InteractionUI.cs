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

    public void NewOrder()
    {
        gameObject.GetComponent<NewOrder>().CreateOrder();
    }

    public void OrderUI()
    {
        GameObject PrefabUI = GameObject.Find("Canvas").GetComponent<PlayerUI>().PrefsUI[1];
        PrefabUI.transform.Find("Info Tab").gameObject.transform.Find("Who").gameObject.SetActive(true);
        PrefabUI.GetComponent<NewOrder>().Region = GameObject.Find("Canvas Region").GetComponent<ListUI>().Id;
        Instantiate(PrefabUI);
    }

    /// <summary>
    /// Generate UI of New Order + write info to global parametrs (Click from Unit Icon)
    /// </summary>
    /// <param name="RegionId"></param>
    /// <param name="Type"></param>
    /// <param name="Unit"></param>
    public void UnitOrderUI(int RegionId, UnitParametrs.AdviserType Type, GameObject Unit)
    {
        GameObject PrefabUI = GameObject.Find("Canvas").GetComponent<PlayerUI>().PrefsUI[1];
        PrefabUI.GetComponent<NewOrder>().Region = RegionId;
        PrefabUI.GetComponent<NewOrder>().Who = Type;
        PrefabUI.GetComponent<NewOrder>().Unit = Unit;
        PrefabUI.transform.Find("Info Tab").gameObject.transform.Find("Who").gameObject.SetActive(false);
        PrefabUI.transform.GetComponent<InteractionUI>().Parent = Unit;
        PrefabUI.transform.Find("Info Tab").gameObject.transform.Find("For").GetComponent<Text>().text = $"For {Type}";
        PrefabUI.GetComponent<NewOrder>().Options = PrefabUI.transform.Find("Order").GetComponent<Dropdown>();
        PrefabUI.GetComponent<NewOrder>().SetOptions();
        Instantiate(PrefabUI);
    }
}
