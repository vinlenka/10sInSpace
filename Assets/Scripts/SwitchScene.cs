using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject player;
    public SpawnAsteroid spawnAsteroid;
    public GameObject buttonController;
    public AlienController alien;

    private ButtonUI buttonUI;
    
    private Vector2 screenBounds;

    private void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (buttonController != null) buttonUI = buttonController.GetComponent<ButtonUI>();
    }

    private void Update() {
        if (spawnAsteroid != null && spawnAsteroid.dangerZonePassed && player.activeSelf) {
            // from danger zone to second safe zone
            LoadNextScene(3);
        }
        else if (player != null && spawnAsteroid == null && OutOfBounds() && player.activeSelf) {

            if (SceneManager.GetActiveScene().buildIndex == 1) // from first safe zone to danger zone
                LoadNextScene(2);

            else if (SceneManager.GetActiveScene().buildIndex == 3) // from second safe back to first safe zone
                LoadNextScene(1);
        }
        else if (player != null && spawnAsteroid != null && OutOfBounds() && player.activeSelf) {
            // from danger zone to first safe zone
            LoadNextScene(1);
        }
        else if (player != null && player.GetComponent<SpaceshipScript>().enteredPuzzle) {
            if (player.GetComponent<SpaceshipScript>().bribedAlien)
            {
                // from second safe zone to puzzle
                LoadNextScene(4);
            } else
            {
                // from second safe zone to alien
                LoadNextScene(5);
            }            
        } 
        else if (buttonUI != null && buttonUI.nextScene) {
            // change to scene according to buttons
            LoadNextScene(buttonUI.nextSceneId);
            buttonUI.nextScene = false;
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
