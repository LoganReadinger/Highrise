using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour { 
    // If player falls off the platform, process the death
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Killzone")) {
            //Destroy(gameObject);
            GameManager.instance.PlayerDeath();
        }
    }
    
    //Method to reset player stats, currently empty
    public void Die() {
        
    }
}
