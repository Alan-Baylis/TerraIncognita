using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {


    public float speed = 10.0f;
    public float gravity = -9.8f;
    public float jumpheight = 3.0f;
    public static float playerHealth = 100;
    public static bool havePliers = false;
    public static bool haveWrench = false;
    public static bool pliersInHand = false;
    public static bool wrenchInHand = false;
    public bool projectorStarted = false;
    public bool haveWeapon = false;
    public Text ammoText;
    public Text healthText;
    public Text keyText;
    public GameObject[] weapons;
    public int score;
    public Text scoreText;
    public static bool generatorStarted = false;
    public GameObject projectorWork0;
    public GameObject projectorWork1;
    public GameObject projectorWork2;
    public GameObject movingWall;
    public Dictionary<string, bool> keys = new Dictionary<string, bool>();

    private CharacterController _charCont;
    private string keyNameTemplate = "Dungeon_Key_Set_";
                                       
    void Start() {
        ammoText.gameObject.SetActive(false);

        _charCont = GetComponent<CharacterController>();

       weapons[0].SetActive(false);

     //   weapons[1].SetActive(true);
        weapons[1].SetActive(false);
        weapons[2].SetActive(false);

    //init keys array
      for (int i = 0; i < 13; i++) {
            keys.Add(keyNameTemplate + i, false);
        }
    }


    void Update() {
        if (playerHealth >=0) {
            healthText.text = playerHealth.ToString();
        }
        
        if (playerHealth > 0&&!LevelComplete.lvlCompleted) {
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
              WearponSwitch();
        }
        else print("You died");


    }


    void OnTriggerEnter(Collider other) {


        if (other.tag == "Wearpon") {
            other.gameObject.SetActive(false);
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            ammoText.gameObject.SetActive(true);
            haveWeapon = true;
            keyText.text = other.tag + " picked";
            pliersInHand = false;
            wrenchInHand = false;
            StartCoroutine("KeyTextShow");
        }
        else if (other.tag == "Energy") {
            other.gameObject.SetActive(false);
            score++;
        }
        else if (other.tag == "Key") {
            //print("GetKey: " + other.name);
            keys[other.name] = true;
            keyText.text = other.tag + " picked";
            StartCoroutine("KeyTextShow");
            other.gameObject.SetActive(false);
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
       // else if (other.tag == "Generator") {
       //     if (score >= 100) {
        //        generatorStarted = true;
         //       generatorWork.gameObject.SetActive(true);
          //  }
       // }
        else if (other.tag == "Wrench") {
            other.gameObject.SetActive(false);
            haveWrench = true;
            weapons[2].SetActive(true);
            weapons[1].SetActive(false);
            weapons[0].SetActive(false);
            keyText.text = other.tag + " picked";
            pliersInHand = false;
            wrenchInHand = true;
            StartCoroutine("KeyTextShow");
        }
        else if (other.tag == "Pliers") {
            other.gameObject.SetActive(false);
            havePliers = true;
            weapons[0].SetActive(false);
            weapons[2].SetActive(false);
            weapons[1].SetActive(true);
            keyText.text = other.tag + " picked";
            pliersInHand = true;
            wrenchInHand = false;
            StartCoroutine("KeyTextShow");
        }
            
            else if (other.tag == "Projector"&& score >= 100&&!projectorStarted) {
                projectorWork0.gameObject.SetActive(true);
                projectorWork1.gameObject.SetActive(true);
                projectorWork2.gameObject.SetActive(true);
                movingWall.gameObject.transform.Translate(4, 0, 0);
                projectorStarted = true;
            }
        }
    
    void WearponSwitch() {
        if (Input.GetKeyDown(KeyCode.Alpha1)&&haveWeapon) {

            weapons[0].SetActive(true);

            weapons[1].SetActive(false);

            weapons[2].SetActive(false);
            pliersInHand = false;
            wrenchInHand = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)&&havePliers) {

            weapons[0].SetActive(false);

            weapons[1].SetActive(true);

            weapons[2].SetActive(false);
            pliersInHand = true;
            wrenchInHand = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&haveWrench) {

            weapons[0].SetActive(false);

            weapons[1].SetActive(false);

            weapons[2].SetActive(true);
            pliersInHand = false;
            wrenchInHand = true;
        }
    }
    IEnumerator KeyTextShow() {
        keyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        keyText.gameObject.SetActive(false);
    }
}