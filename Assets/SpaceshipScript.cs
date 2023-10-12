using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
 
        rb.velocity = new Vector2 (moveHorizontal*speed, moveVertical*speed);
    }
}
