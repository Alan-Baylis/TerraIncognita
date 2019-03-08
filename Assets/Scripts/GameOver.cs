using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject gameOverPanel;

    void Start() {
        gameOverPanel.SetActive(false);
    }
    void Update() {
        if (PlayerController.playerHealth <= 0) {
            gameOverPanel.SetActive(true);

        }
    }
    public void RestartBtn() {
        gameOverPanel.SetActive(false);
        PlayerController.playerHealth = 100;
        SceneManager.LoadScene("Lvl1", LoadSceneMode.Single);
    }
    public void StartLevel() {
        SceneManager.LoadScene("Lvl1", LoadSceneMode.Single);
    }
    public void ExitGameBtn() {
        Application.Quit();
    }
}