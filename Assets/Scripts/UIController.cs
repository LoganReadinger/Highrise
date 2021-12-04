using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    //Variable declaration
    public Text distance;

    //Pause
    public GameObject pausePanel;
    public Button resume;
    public Button pauseQuit;

    //Win
    public GameObject winPanel;
    public Button nextLevel;
    public Button winQuit;
    public Text winDescription;

    //Death
    public Text deathText;
    
    //Other
    float distanceValue;
    float winDistance;
    bool pauseEnabled;

	//Start method for initialization and button listener adding. Also disables the other UI elements
	void Start () {
        distanceValue = 0f;
        winDistance = 100f;
        pauseEnabled = false;
        deathText.enabled = false;

        pauseQuit.onClick.AddListener(delegate { quitButton(); });
        winQuit.onClick.AddListener(delegate { quitButton(); });
        resume.onClick.AddListener(delegate { DisablePauseMenu(); });


        DisablePauseMenu();
        DisableWinMenu();
    }

    //Update method for pause menu, win menu, and death screen processing
    void Update() {
        if(Input.GetKeyDown("escape")) {
            //check if game is already paused       
            if(pauseEnabled == true) {
                pauseEnabled = false;
                DisablePauseMenu();
            }
            //else if game isn't paused, then pause it
            else if(pauseEnabled == false) {
                EnablePauseMenu();
            }
        }

        if(distanceValue >= winDistance) {
            win();
            EnableWinMenu();
        }

        if(GameManager.instance.playerDied == true) {
            deathShow();
        } else if(GameManager.instance.playerDied == false) {
            deathHide();
        }
    }

    //FixedUpdate method for distance calculation and UI update
    void FixedUpdate () {
        distanceValue += 0.02f;
        
        distance.text = "Distance: " + (distanceValue.ToString("F0")) + "/100";
    }

    //Enable Pause menu UI elements
    private void EnablePauseMenu() {
        pausePanel.SetActive(true);
        resume.enabled = true;
        pauseQuit.enabled = true;

        distance.enabled = false;

        Time.timeScale = 0;
    }
    
    //Disable Pause menu UI elements
    private void DisablePauseMenu() {
        pausePanel.SetActive(false);
        resume.enabled = false;
        pauseQuit.enabled = false;

        distance.enabled = true;

        Time.timeScale = 1;
    }

    //Enable Win menu UI elements
    private void EnableWinMenu() {
        winPanel.SetActive(true);
        winQuit.enabled = true;
        nextLevel.enabled = true;
        winDescription.enabled = true;
    }

    //Disable Win menu UI elements
    private void DisableWinMenu() {
        winPanel.SetActive(false);
        winQuit.enabled = false;
        nextLevel.enabled = false;
        winDescription.enabled = false;
    }

    //Change scene to main menu
    void quitButton() {
        SceneManager.LoadScene("MainMenu");
    }

    //Stop game if won
    void win() {
        Time.timeScale = 0;
        distance.enabled = false;
    }

    //Enable death text
    void deathShow() {
        deathText.enabled = true;
        distance.enabled = false;
    }

    //Disable death text
    void deathHide() {
        deathText.enabled = false;
        distance.enabled = true;
    }

}
