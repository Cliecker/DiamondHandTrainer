using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //backend
    DateTime SeedDate;
    public float SeedSeconds;

    public float SecondsSeedMultiplier, DaySeedMultiplier, HourSeedMultiplier;
    private float SecondPNSeed, DayPNSeed, HourPNSeed;

    public float value;
    public float secondBaseValue, hourBaseValue, DayBaseValue;

    //player 
    public float worth;
    public float cash;
    public bool bought;
    public float shares;

    //gameplay 
    public float WorkPayout = 7.25f; 

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SeedDate = new DateTime(2020, 3, 1, 7, 0, 0, System.DateTimeKind.Utc);
    }

    // Update is called once per frame
    void Update()
    {
        SeedSeconds = (int)(DateTime.UtcNow - SeedDate).TotalSeconds % 2000000;

        SecondPNSeed = SeedSeconds;
        HourPNSeed = SeedSeconds * HourSeedMultiplier;
        DayPNSeed = SeedSeconds * DaySeedMultiplier;

        float secAmt = Mathf.PerlinNoise(SecondPNSeed, SecondPNSeed) * secondBaseValue;
        float hourAmt = Mathf.PerlinNoise(HourPNSeed, HourPNSeed) * hourBaseValue;
        float dayAmt = Mathf.PerlinNoise(DayPNSeed, DayPNSeed) * DayBaseValue;

        value = secAmt + hourAmt + dayAmt;
        //print($"{value} = {secAmt} + {hourAmt} + {dayAmt} , seed {SeedSeconds}"); 

        worth = cash + shares * value; 
    }

    public void OnActionButtonPressed()
    {
        if (bought)
            Sell();
        else
            Buy();
    }
    public void Work()
    {
        cash += WorkPayout; 
    }
    public void Buy()
    {
        if (bought)
            return;
        shares = cash / value;
        cash = 0f; 

        bought = true;
    }

    public void Sell()
    {
        if (!bought)
            return;
        
        cash = shares * value;
        shares = 0;

        bought = false; 
    }
}
