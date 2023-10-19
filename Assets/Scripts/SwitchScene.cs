using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject player;
    public SpawnAsteroid spawnAsteroid;
    
    private Vector2 screenBounds;

    private void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update() {
        if (spawnAsteroid != null && spawnAsteroid.dangerZonePassed)
            LoadNextScene();
        
        if (player != null && OutOfBounds())
            LoadNextScene();
        
    }
    
    private void LoadNextScene() {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings) {
            Debug.Log("Scene change!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    public bool OutOfBounds() {
        return player.transform.position.x < screenBounds.x * (-1.5) ||
               player.transform.position.x > screenBounds.x * 1.5 ||
               player.transform.position.y < screenBounds.y * (-1.5) ||
               player.transform.position.y > screenBounds.y * 1.5;
    }
    
}
