using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ListUI : MonoBehaviour
{
    public int Id;

    //UI list for Region Info window
    public List<Text> RegionInfo = new List<Text>();

    //UI list for clock UI
    public List<Text> Clock = new List<Text>();

    //UI text for info window
    public List<Text> WindowInfo = new List<Text>();

    //UI objects of info window
    public List<GameObject> WindowObj = new List<GameObject>();

    //Texts GO
    public List<Text> TextFields;
}
