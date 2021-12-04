using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public Button start;
    public Text startText;
    public Button quit;
    public Text quitText;
    public Text title;

    private int menuIndex;

	//Start method for initialization and button listener addition
	void Start () {
        menuIndex = 0;

        start.onClick.AddListener(delegate { startGame(); });
        quit.onClick.AddListener(delegate { quitGame(); });

	}
	
	//Update method for up/down and enter/return processing
	void Update () {
        if(menuIndex == 0) {
            if(Input.GetKeyDown("s") || Input.GetKeyDown("down") || Input.GetKeyDown("w") || Input.GetKeyDown("up")) {
                menuIndex = 1;
                changeSelected();   
            }else if(Input.GetKeyDown("enter") || Input.GetKeyDown("return")) {
                startGame();
            }

        } else if(menuIndex == 1) {
            if(Input.GetKeyDown("s") || Input.GetKeyDown("down") || Input.GetKeyDown("w") || Input.GetKeyDown("up")) {
                menuIndex = 0;
                changeSelected();
            } else if(Input.GetKeyDown("enter") || Input.GetKeyDown("return")) {
                quitGame();
            }
        }
    }

    //Change UI for selected option
    void changeSelected() {
        if(menuIndex == 0) {
            startText.text = ">Start";
            quitText.text = "Quit";
        } else if(menuIndex == 1) {
            startText.text = "Start";
            quitText.text = ">Quit";
        }
    }

    //Load first level scene
    void startGame() {
        SceneManager.LoadScene("InnerCity");
    }

    //Exit the application
    void quitGame() {
        Application.Quit();
    }
}
