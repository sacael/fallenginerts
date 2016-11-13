﻿using UnityEngine;using UnityEngine.UI;using System.Collections;/// <summary>
/// script of gestion of the cost panel
/// </summary>public class CostPanel : MonoBehaviour {    public Text woodText;    public Text ironText;    public Text foodText;    public Text populationText;    /// <summary>
    /// Update the cost on the interface with the values
    /// </summary>
    /// <param name="wood">number of wood to print</param>
    /// <param name="iron">number of iron to print</param>
    /// <param name="food">number of food to print</param>
    /// <param name="population">number of population to print</param>    public void UpdateCost(int wood,int iron,int food,int population)    {        woodText.text = wood.ToString();        ironText.text = iron.ToString();        foodText.text = food.ToString();        populationText.text = population.ToString();    }}