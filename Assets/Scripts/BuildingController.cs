using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {
    private float startingSpeed = 10f;
    private float currentSpeed;
    private float terminalVelocity = 150f;

    //Start method to assign a default speed and death timer
    void Start() {
        currentSpeed = startingSpeed;
        Destroy(gameObject, 8f);
    }

    //FixedUpdate method to gradually change the speed of platforms
    void FixedUpdate () {
        if(currentSpeed <= terminalVelocity)
            currentSpeed += 0.02f;
        else
            currentSpeed = terminalVelocity;

        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
	}

}
