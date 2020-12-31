using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    Economy PlayerEconomy = new Economy();
    public Text GoldUI;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText();
    }

    public void goldText()
    {
        int gold = PlayerEconomy.GetGold();
        GoldUI.text = $"Gold: {gold}";
    }
}
