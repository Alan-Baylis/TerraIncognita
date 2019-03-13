using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour {
    public GameObject lvlComplete;
   // public Text lvlComplete;
   // Use this for initialization
    void Start () {
        lvlComplete.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
       
       if (other.tag == "Player"&&PlayerController.haveWrench && PlayerController.havePliers && PlayerController.generatorStarted) {
            //  lvlComplete.text = "Level complete!!";
            StartCoroutine("LevelCompleted");
        }
    }//
    IEnumerator LevelCompleted() {
        yield return new WaitForSeconds(1.0f);
        lvlComplete.SetActive(true);
       // yield return new WaitForSeconds(2.0f);
        //SceneManager.LoadScene("Start");
    }
}
