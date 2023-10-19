using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Random = UnityEngine.Random;

public class SpawnAsteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 0.5f;
    public int SpawnersAmount = 2;
    public bool dangerZonePassed;
    
    private Vector2 screenBounds;
    private bool within10s;
    private float startTime;
    
    // Start is called before the first frame update
    void Start() {
        dangerZonePassed = false;
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        within10s = true;
        startTime = Time.realtimeSinceStartup;
        
        for (int i = 0; i < SpawnersAmount; i++) {
            StartCoroutine(AsteroidSpawner());
        }
    }

    private void Update() {
        if (Time.realtimeSinceStartup - startTime >= 10f) {
            within10s = false;
        }
        
        if (Time.realtimeSinceStartup - startTime >= 13f) {
            dangerZonePassed = true;
        }
    }

    private void SpawnEnemy() {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = RandomSpawnPosition();
    }
    
    IEnumerator AsteroidSpawner() {
        while (within10s) {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }

    private Vector2 RandomSpawnPosition() {
        float x = Random.Range(-screenBounds.x, screenBounds.x) * 1.5f;
        float y;


        if (x < -screenBounds.x || x > screenBounds.x) {
            
            // if x is to the right or the left of the camera, there is no restriction to y
            
            y = Random.Range(-screenBounds.y, screenBounds.y) * 1.5f;
        }
        else {
            
            // if x is within the camera, the y must be either above or below the camera so that he does not 
            // spawn in the middle of the screen
            
            if (Random.Range(0, 1) <= 0.5)  // quick and dirty random to assess if asteroid should spawn above or below camera
                y = Random.Range(screenBounds.y * 1.2f, screenBounds.y * 1.5f); // above
            else
                y = Random.Range(-screenBounds.y * 1.5f, -screenBounds.y * 1.2f); // below
        }
        
        return new Vector2(x, y);
    }
    
}
