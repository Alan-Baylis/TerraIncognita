using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour {
    public GameObject lvlComplete;
    public GameObject generatorWork;
    // public Text lvlComplete;
    public static bool lvlCompleted = false;
   // Use this for initialization
    void Start () {
        lvlComplete.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
       
       if (other.tag == "Player"&&PlayerController.haveWrench && PlayerController.havePliers && PlayerController.generatorStarted&&PlayerController.wrenchInHand) {
            //  lvlComplete.text = "Level complete!!";
            lvlCompleted = true;
            StartCoroutine("LevelCompleted");
        }
    }//
    IEnumerator LevelCompleted() {
        generatorWork.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        lvlComplete.SetActive(true);
       // yield return new WaitForSeconds(2.0f);
        //SceneManager.LoadScene("Start");
    }
}
