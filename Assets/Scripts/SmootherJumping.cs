using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmootherJumping : MonoBehaviour {
    //Variable declaration
    private float jumpForce = 25f;
    private float fallMultiplier = 5f;
    private float lowJumpMultiplier = 2f;
    Rigidbody2D rgbdy;

	//Start method to assign the rigidbody
	void Start () {
        rgbdy = GetComponent<Rigidbody2D>();
	}

    //Update method to perform the basic jump
    private void Update() {
        if(Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }    
    }

    //FixedUpdate method to calculate short and long hops
    void FixedUpdate () {
        if(rgbdy.velocity.y < 0) {
            rgbdy.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if(rgbdy.velocity.y > 0 && !Input.GetButton("Jump")) {
            rgbdy.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
}
