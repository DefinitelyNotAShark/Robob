using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour {

    [HideInInspector]
    public int points = 0;
    [HideInInspector]
    public int amountOfPointsTillUpgrade = 1;
    [HideInInspector]
    public int amountOfPointsTillWin = 3;

    public void AddPoints(int pointAmount)
    {
        points += pointAmount;
    }

    private void Update()
    {
        CheckIfUpgrade(amountOfPointsTillUpgrade);
        CheckIfWin(amountOfPointsTillWin);
    }

    private bool CheckIfWin(int pointAmount)
    {
        if (points == pointAmount)
        {
            return true;
        }
        else return false;
    }

    private bool CheckIfUpgrade(int pointAmount)
    {
        if (points == pointAmount)
        {
            return true;
        }
        else return false;
    }
}
