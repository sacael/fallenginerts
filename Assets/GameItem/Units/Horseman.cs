﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Horseman Unit
/// </summary>
class Horseman : Unit {

    public static int woodcost = 10;
    public static int ironcost = 30;
    public static int foodcost = 50;
    public static int populationcost = 1;
    public override void SetIronCost(int newPrice)
    {
        ironcost = newPrice;
    }

    public override void SetWoodCost(int newPrice)
    {
        woodcost = newPrice;
    }

    public override void SetFoodCost(int newPrice)
    {
        foodcost = newPrice;
    }

    public override int GetIronCost()
    {
        return ironcost;
    }

    public override int GetFoodCost()
    {
        return foodcost;
    }

    public override int GetWoodCost()
    {
        return woodcost;
    }


    public override void SetPopulationCost(int i)
    {
        populationcost = i;
    }

    public override int GetPopulationCost()
    {
        return populationcost;
    }
}