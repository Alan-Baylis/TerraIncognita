using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {


    public float speed = 10.0f;
    public float gravity = -9.8f;
    public float jumpheight = 3.0f;
    public static float playerHealth = 100;
    public static bool haveKey = false;
    public Text ammoText;
    public GameObject[] weapons;
    public int score;
    public Text scoreText;
    public bool startedGenerator = false;
    public Dictionary<string, bool> keys = new Dictionary<string, bool>();

    private CharacterController _charCont;
    private string keyNameTemplate = "Dungeon_Key_Set_";
                                       
    void Start() {
        ammoText.gameObject.SetActive(false);

        _charCont = GetComponent<CharacterController>();

       weapons[0].SetActive(false);

     //   weapons[1].SetActive(true);
      //  weapons[2].SetActive(false);
      //  weapons[3].SetActive(false);

    //init keys array
      for (int i = 0; i < 13; i++) {
            keys.Add(keyNameTemplate + i, false);
        }
    }


    void Update() {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _charCont.Move(movement);
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 jump = new Vector3(0, jumpheight, 0);
            jump = Vector3.ClampMagnitude(jump, jumpheight);
            _charCont.Move(jump);
        }
        scoreText.text = score.ToString();
      //  WeaponSwitch();

    }


    void OnTriggerEnter(Collider other) {
        if (other.tag == "Wearpon") {
            other.gameObject.SetActive(false);
            weapons[0].SetActive(true);
            ammoText.gameObject.SetActive(true);
        }
        else if (other.tag == "Energy") {
            other.gameObject.SetActive(false);
            score++;
        }
        else if (other.tag == "Key") {
            print("GetKey: " + other.name);
            keys[other.name] = true;

            other.gameObject.SetActive(false);
            haveKey = true;
        }
        else if (other.tag == "Door") {
            string doorIndex = other.name.Substring(5, other.name.Length - 5);

            // print("door name " + doorIndex);
            // print("have key for the door #" + doorIndex + " - " + keys[keyNameTemplate + doorIndex]);

            if (keys[keyNameTemplate + doorIndex] == true) {

                other.gameObject.SetActive(false);
            }
        }
        else if (other.tag == "Battery_small") {
            score += 3;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Battery_big") {
            score += 5;
            other.gameObject.SetActive(false);
        }
        else if (other.tag=="Generator") {
            if (score >=40) {
                startedGenerator = true;
            }
        }
    }
}