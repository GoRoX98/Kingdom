using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.Windows;
using UnityEditor;
using System;

public class NewOrder : MonoBehaviour
{
    public GameObject PrefabUnit;
    public GameObject PrefabUI;
    public GameObject World;

    public int Region;
    public UnitParametrs.AdviserType Who;
    public GameObject Unit;
    public Dropdown Options;
    public Dropdown AdviserType;

    void Start()
    {
        World = GameObject.Find("World");
        PrefabUI = gameObject;
        Options = GameObject.Find("Order").GetComponent<Dropdown>();
        AdviserType = gameObject.transform.Find("Info Tab").Find("Who").GetComponent<Dropdown>();
        PrefabUI.transform.Find("Info Tab").Find("Description").GetComponent<Text>().text = $"Order for region: {Region}";
    }

    void FixedUpdate()
    {
        if(PrefabUI.transform.Find("Info Tab").Find("Who").gameObject.activeSelf)
        {
            InitializedParam();
        }
    }

    /// <summary>
    /// Update Dropdown menu in UI of New Order
    /// </summary>
    /// <param name="Options">Dropdown menu in UI</param>
    /// <param name="Type">Type of Adviser</param>
    public void SetOptions()
    {
        if (Who == UnitParametrs.AdviserType.Architect)
        {
            Options.options[1].text = "Build";
            Options.options[2].text = "Boost";
            Options.options[3].text = "Repair";
        }
        if (Who == UnitParametrs.AdviserType.Capitan)
        {
            Options.options[1].text = "Boost";
            Options.options[2].text = "Explore";
            Options.options[3].text = "Repair";
        }
        if (Who == UnitParametrs.AdviserType.Spy)
        {
            Options.options[1].text = "Spy";
            Options.options[2].text = "Subotage";
            Options.options[3].text = "Explore";
        }
    }

    public void InitializedParam()
    {
        //print($"{AdviserType.captionText.text}");
        Who = (UnitParametrs.AdviserType)Enum.Parse(typeof(UnitParametrs.AdviserType), AdviserType.captionText.text);
        SetOptions();
        Unit = GameObject.Find($"{AdviserType.captionText.text}");
    }

    public void CreateOrder()
    {
        if (Options.captionText.text == "None") print("You choose nothing");
        if (Options.captionText.text == "Build") print("You choose Build");
        if (Options.captionText.text == "Boost") print("You choose Boost");
        if (Options.captionText.text == "Repair") print("You choose Repair");
        if (Options.captionText.text == "Explore") print("You choose Explore");
        if (Options.captionText.text == "Spy") print("You choose Spy");
        if (Options.captionText.text == "Subotage") print("You choose Subotage");
        OrderStruct Order = Unit.GetComponent<Unit>().UnitOrder;

        //If adviser in the castle
        if (Unit.GetComponent<Unit>().RegionIdPosition == 0) Unit.GetComponent<Unit>().UnitOrder.NewOrder(Region, Order.ToOrderType(Options.captionText.text));
        else SendMessenger(Order);
    }

    private void SendMessenger(OrderStruct Order)
    {
        PrefabUnit.name = "Messenger";
        PrefabUnit.transform.localScale = new Vector2(0.3f, 0.3f);
        PrefabUnit.transform.position = new Vector2(World.transform.Find("Castle").transform.position.x + 5f, World.transform.Find("Castle").transform.position.y);
        Order = new OrderStruct(false, Region, Order.ToOrderType(Options.captionText.text));
        PrefabUnit.GetComponent<Unit>().Type = global::Unit.UnitType.Messenger;
        PrefabUnit = Instantiate(PrefabUnit, World.transform);
        PrefabUnit.GetComponent<Unit>().NewMessege(Unit, Order);
    }
}
