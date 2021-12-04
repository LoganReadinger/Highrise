using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    //private RaycastHit2D hit;
    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;
    private RaycastHit2D hitUp;

    // Use this for initialization
    void Start() {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update() {
        //hit = Physics2D.Raycast(transform.position, Vector2.down, 0.9f);
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.5f);
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.5f);
        hitUp = Physics2D.Raycast(transform.position, Vector2.up, 0.5f);

        //Debug.DrawRay(transform.position,hitUp,Color.red);
        //Debug.DrawRay(transform.position, new Vector2(0, -0.9f), Color.red, 1f);

        
        //is the player touching the enemy 
        if(hitLeft.collider != null && !GameManager.instance.playerDied)
            if(hitLeft.collider.gameObject.CompareTag("Player"))
                // kill off player 
                GameManager.instance.PlayerDeath();
        if(hitRight.collider != null && !GameManager.instance.playerDied)
            if(hitRight.collider.gameObject.CompareTag("Player"))
                // kill off player 
                GameManager.instance.PlayerDeath();

        if(hitUp.collider != null && !GameManager.instance.playerDied) {
            GameManager.instance.PlayerDeath();
        }
    }
}
