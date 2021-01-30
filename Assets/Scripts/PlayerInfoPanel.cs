using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class PlayerInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI worth, shares, cash; 

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        worth.text = GameManager.instance.worth.ToMoney();
        cash.text = GameManager.instance.cash.ToMoney();
        shares.text = GameManager.instance.shares.ToString(); 
    }
}
