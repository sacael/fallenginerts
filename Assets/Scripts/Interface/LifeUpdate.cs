﻿using UnityEngine;using System.Collections;/// <summary>
/// Script of update of the life of the players
/// </summary>public class LifeUpdate : MonoBehaviour {    public TextMesh life;    public Player player;	// update of the life of a player on the interface (the number of units in the reserve army=	void Update () {        life.text = player.reserveArmy.TotalUnit.ToString();	}}