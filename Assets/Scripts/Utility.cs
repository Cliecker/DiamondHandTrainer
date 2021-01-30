using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    //utility
    public static string ToMoney(this float s)
    {
        
        return string.Format("${0:.##}", s);
    }
}

