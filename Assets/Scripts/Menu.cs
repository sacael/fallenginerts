﻿using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	void Start () {
	}
	
	void Update () {
	
	}

    public void HandleMenu() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    public void HandlePause() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);

        if (this.gameObject.activeSelf) {
             Time.timeScale = 0f;
         } else {
             Time.timeScale = 1f;
         }
    }
}