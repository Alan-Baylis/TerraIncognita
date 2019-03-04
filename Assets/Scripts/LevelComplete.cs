using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelComplete : MonoBehaviour {
    public Text lvlComplete;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"&&PlayerController.haveKey) {
            lvlComplete.text = "Level complete!!";
        }
    }
}
