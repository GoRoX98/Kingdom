using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.Windows;
using UnityEditor;

public class NewOrder : MonoBehaviour
{
    public GameObject PrefabUI;
    private int Region;
    private UnitParametrs.AdviserType Who;
    private GameObject Unit;
    private Dropdown Options;

    void Start()
    {
        PrefabUI = GameObject.Find("Canvas").GetComponent<PlayerUI>().PrefsUI[1];
    }

    /// <summary>
    /// Generate UI of New Order + write info to global parametrs
    /// </summary>
    /// <param name="RegionId"></param>
    /// <param name="Type"></param>
    /// <param name="Unit"></param>
    public void OrderUI(int RegionId, UnitParametrs.AdviserType Type, GameObject Unit)
    {
        Region = RegionId;
        Who = Type;
        this.Unit = Unit;
        PrefabUI.transform.GetComponent<InteractionUI>().Parent = Unit;
        PrefabUI.transform.Find("Info Tab").gameObject.transform.Find("For").GetComponent<Text>().text = $"For {Type}";
        PrefabUI.transform.Find("Info Tab").gameObject.transform.Find("Description").GetComponent<Text>().text = $"Order for region: {RegionId}";
        Options = PrefabUI.transform.Find("Order").GetComponent<Dropdown>();
        SetOptions();
        Instantiate(PrefabUI);
        Options = GameObject.Find("Order").GetComponent<Dropdown>();
    }

    /// <summary>
    /// Update Dropdown menu in UI of New Order
    /// </summary>
    /// <param name="Options">Dropdown menu in UI</param>
    /// <param name="Type">Type of Adviser</param>
    private void SetOptions()
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
    
    public void CreateOrder()
    {
        if (Who == UnitParametrs.AdviserType.Architect)
        {
            if (Options.captionText.text == "None") print("You choose nothing");
            if (Options.captionText.text == "Build") print("You choose Build");
            if (Options.captionText.text == "Boost") print("You choose Boost");
            if (Options.captionText.text == "Repair") print("You choose Repair");
        }
    }

}
