using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Screen = UnityEngine.Device.Screen;

public class AsteroidScript : MonoBehaviour {

    public float speed = 10.0f;
    public bool extraRandom = false;
    
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Vector2 velocity;
    
    // Start is called before the first frame update
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();

        if (extraRandom)
            velocity = new Vector2(transform.position.x * Random.Range(0.25f, 0.75f), transform.position.y * Random.Range(0.25f, 0.75f)).normalized * (-speed);
        else 
            velocity = new Vector2(transform.position.x, transform.position.y).normalized * (-speed);
        
        rb.velocity = velocity;
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (OutOfBounds()) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("spaceship"))
        {
            Debug.Log("Collision!");

            Destroy(this.gameObject);
            LevelManager.manager.GameOver();
        }
    }


    private bool OutOfBounds() {
        return transform.position.x < screenBounds.x * (-4) ||
               transform.position.x > screenBounds.x * 4 ||
               transform.position.y < screenBounds.y * (-4) ||
               transform.position.y > screenBounds.y * 4;
    }
    
}
