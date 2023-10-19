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
        if (spawnAsteroid != null && spawnAsteroid.dangerZonePassed && player.activeSelf) {
            // from danger zone to second safe zone
            LoadNextScene(2);
        }
        else if (player != null && spawnAsteroid == null && OutOfBounds() && player.activeSelf) {

            if (SceneManager.GetActiveScene().buildIndex == 0) // from first safe zone to danger zone
                LoadNextScene(1);

            else if (SceneManager.GetActiveScene().buildIndex == 2) // from second safe back to first safe zone
                LoadNextScene(0);
        }
        else if (player != null && spawnAsteroid != null && OutOfBounds() && player.activeSelf) {
            // from danger zone to first safe zone
            LoadNextScene(0);
        }
        else if (player != null && player.GetComponent<SpaceshipScript>().enteredPuzzle) {
            // from second safe zone to puzzle
            LoadNextScene(3);
        } 
    }
    
    private void LoadNextScene(int index) {
        Debug.Log("Scene change to scene - " + index);
        SceneManager.LoadScene(index);
    }
    
    public bool OutOfBounds() {
        return player.transform.position.x < screenBounds.x * (-1.5) ||
               player.transform.position.x > screenBounds.x * 1.5 ||
               player.transform.position.y < screenBounds.y * (-1.5) ||
               player.transform.position.y > screenBounds.y * 1.5;
    }
    
}
