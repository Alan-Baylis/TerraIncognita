﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PliersPick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
          //  PlayerController.havePliers = true;
            //this.gameObject.SetActive(false);
        }
    }
}
