using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    //Variable Declaration
    public static GameManager instance = null;

    public bool playerDied;

    //Platform variables
    public GameObject platformSpawnPoint;
    public GameObject[] platforms = new GameObject[3];
    GameObject currentPlatform;

    //Spawning variables
    private float timeBetweenSpawns;
    private float startTimeBetweenSpawns;
    private int counter=0;
    private int i;

    //Enemy variables
    //public GameObject enemySpawnPoint;
    //public GameObject enemy;
    //private GameObject[] enemies;


    //Awake method to utilize Singleton 
    void Awake(){
      if(instance == null)
        instance = this;
      else if(instance != this) 
        Destroy(gameObject);

        DontDestroyOnLoad(gameObject);        
    }

    //Start method to assign variables
    void Start() {
        platformSpawnPoint = GameObject.FindGameObjectWithTag("BuildingSpawner");
        //enemySpawnPoint = GameObject.FindGameObjectWithTag("EnemySpawner");

        startTimeBetweenSpawns = 2.2f;
        i = 0;
    }

    //Update method that spawns platforms (could be moved to BuildingController)
    void Update() {
        if(SceneManager.GetActiveScene().name == "InnerCity" & !playerDied) {
            currentPlatform = platforms[randomRange()];

            if(timeBetweenSpawns <= 0) {
                Instantiate(currentPlatform, new Vector3(platformSpawnPoint.transform.position.x, currentPlatform.transform.position.y, currentPlatform.transform.position.z), Quaternion.identity);
                timeBetweenSpawns = startTimeBetweenSpawns;
            } else {
                timeBetweenSpawns -= Time.deltaTime;
            }

            counter++;
        }
    }

    //Method to randomize the index that will spawn a platform
    public int randomRange() {
        i = Random.Range(0, 3);

        return i;
    }

    //Control all the events that happen when a player dies
    public void PlayerDeath(){
        playerDied = true;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null){
            player.GetComponent<PlayerController>().Die();
        }

        // restarts the game in 2 seconds
        Invoke("RestartGame", 2f);

    }

    //Restarting the game if the player dies
    private void RestartGame(){
        //restart scene
        SceneManager.LoadScene(0);
        //reset player status so the game can resume
        playerDied = false;
    }
    
}

