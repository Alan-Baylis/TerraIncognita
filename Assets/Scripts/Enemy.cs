using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Enemy : MonoBehaviour {
    
    public float enemyHealth = 50.0f;
    
    public void TakeDamage(float amount) {

        enemyHealth -= amount;

        if (enemyHealth <= 0f) {

            Dead();

        }
    }

    void Dead() {

        gameObject.SetActive(false);

    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlayerController.playerHealth -= 10;
        }
    }

}