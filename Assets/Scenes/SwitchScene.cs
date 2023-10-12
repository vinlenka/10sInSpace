using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject player;
    public GameObject ISS;
    // public GameObject gm;
    public string m_Scene;
    public float time;
    public float currentTime;
    public Scene currentScene; 
    public bool inDanger;


    // void OnTriggerEnter(Collider other){
    //     SceneManager.LoadScene(1);

    // }
    // Start is called before the first frame update
    void Start()
    {
        m_Scene = "DangerZoneScene";
        time=0;
        inDanger=false;
        // gm=this;


    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if(!inDanger){
            if(Vector2.Distance(player.transform.position, ISS.transform.position)>5){
                time=0;
                currentTime = Time.realtimeSinceStartup;
                //  StartCoroutine(LoadYourAsyncScene());

                DontDestroyOnLoad(player);
                DontDestroyOnLoad(this);

                // Load the new scene
                // SceneManager.LoadScene(sceneToLoad);

                SceneManager.LoadScene(1);
                // SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(m_Scene));
                // SceneManager.UnloadSceneAsync(currentScene);
                inDanger=true;
            }
        }
        if ( inDanger){
            if(Time.realtimeSinceStartup-currentTime >= 5){
                inDanger=false;
                DontDestroyOnLoad(player);

                SceneManager.LoadScene(0);
                
            }
        }
    }
    

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(m_Scene));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
    
    
    

}
