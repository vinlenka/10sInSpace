using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class AsteroidScript : MonoBehaviour {

    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Vector2 velocity;
    
    // Start is called before the first frame update
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();

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

    private bool OutOfBounds() {
        return transform.position.x < screenBounds.x * (-4) ||
               transform.position.x > screenBounds.x * 4 ||
               transform.position.y < screenBounds.y * (-4) ||
               transform.position.y > screenBounds.y * 4;
    }
    
}
