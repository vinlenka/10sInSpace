using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 25f;
    public float rotationSpeed = 720f;

    [HideInInspector]
    public bool enteredPuzzle = false;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Asteroid")) {
            Debug.Log("Collision!");
            
            Destroy(other.gameObject);
            
            this.gameObject.SetActive(false);
        }
        
        if (other.gameObject.tag.Equals("Puzzle")) {
            Debug.Log("Entering Puzzle");
            enteredPuzzle = true;
        }
    }

    private void PlayerMovement() {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        
        Vector2 movementDirection = new Vector2(moveHorizontal, moveVertical);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        
        transform.Translate(movementDirection * (speed * inputMagnitude * Time.deltaTime), Space.World);

        if (movementDirection != Vector2.zero) {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    
}
