using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            for (int i = 0; i < damage; i++) {
                PlayerController.playerHealth -= 1;
            }
            this.gameObject.SetActive(false);
        }
    }
}
