using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"&&!PlayerController.pliersInHand) {
            PlayerController.playerHealth = 0;
        }
        else if (other.tag == "Player"&&PlayerController.pliersInHand) {
           this.gameObject.SetActive(false);
        }
    }
}
