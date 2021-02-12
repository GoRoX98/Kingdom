using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldList : MonoBehaviour
{
    //List of builddings
    public List<GameObject> Buildings = new List<GameObject>();
    //List of Seasons in the year
    public List<string> Season = new List<string> { "spring", "summer", "autumn", "winter" };
    //List of Month
    public List<string> Month = new List<string> { "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "Junuary", "February" };

}
