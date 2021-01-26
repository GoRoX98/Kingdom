using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class objInfo : MonoBehaviour
{
    public GameObject pref;
    private Text Title;
    private Text Id;
    private Text Description;
    private Text Owner;

    /// <summary>
    /// 1 - print Structure Region of this GameObj
    /// 2 - Ask Id of this gameObject
    /// 3 - Create UI prefab of IngoRegion for this Region
    /// 4 - Generate UI(ask List for this UI, id for this region)
    /// </summary>
    public void OnMouseDown()
    {
        gameObject.GetComponent<Region>().InfoRegion(gameObject);
        int id = gameObject.GetComponent<Region>().Id();
        Instantiate(pref);
        UpdateText(GameObject.Find("Canvas Region").GetComponent<ListUI>().RegionInfo, id);
    }

    /// <summary>
    /// 1 - Ask StrucRegion of Data
    /// i - temp parametr
    /// </summary>
    /// <param name="parent">List for this UI type</param>
    /// <param name="id">Id of this Region</param>
    public void UpdateText(List<Text> parent, int id)
    {
        string[] InfoRegion = gameObject.GetComponent<Region>().Regions[id].Data();
        int i = 0;
        while (3 > i)
        {
            parent[i].text = InfoRegion[i];
            i++;
        }

    }

}
