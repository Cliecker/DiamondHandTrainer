using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class UserInterface : MonoBehaviour
{

    public TextMeshProUGUI SharesDisplay, BuyButton;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SharesDisplay.text = GameManager.instance.value.ToMoney();
        BuyButton.text = GameManager.instance.bought ? "SELL" : "BUY"; 
    }
}
