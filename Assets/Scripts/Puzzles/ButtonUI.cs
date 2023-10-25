using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

public class ButtonUI : MonoBehaviour {

    public GameObject Spaceship;
    
    [SerializeField] GameObject DisplayScreen;
    private List<string> userPass = new List<string>();
    private string[] pass = { "Water", "Gas", "Down" };

    [HideInInspector] public bool nextScene = false;
    [HideInInspector] public int nextSceneId;
    
    public void StartControlPanel()
    {
        Debug.Log("Starting...");
        foreach (GameObject wordButton in GameObject.FindGameObjectsWithTag("WordButton"))
        {
            Debug.Log(wordButton.name);
            Button btn = wordButton.GetComponent<Button>();
            btn.interactable = true;
        }
    }

    public void PrintWordOnScreen(TMP_Text text)
    {
        //Debug.Log(this.gameObject.GetComponentInChildren<TMP_Text>().text);
        DisplayScreen.GetComponent<TMP_Text>().text = text.text;
        
        userPass.Add(text.text);


    }

    public void StartEnteringPass()
    {
        userPass.Clear();
        DisplayScreen.GetComponent<TMP_Text>().text = "";
    }

    public void SumbitPass()
    {
        bool isCorrect = true;

        if (userPass.Count == pass.Length)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] != userPass.ElementAt(i))
                {
                    isCorrect = false;
                    break;
                }


            }
        } else isCorrect = false;
        if (isCorrect) {
            nextScene = true;
            nextSceneId = 3;
            Spaceship.GetComponent<ItemCollector>().IncreaseCredits(100);
            
            DisplayScreen.GetComponent<TMP_Text>().text = "Success";

        } else
        {
            DisplayScreen.GetComponent<TMP_Text>().text = "Try again";
        }
    }
    public void BribeAlien()
    {
        if (ItemCollector.Bribe >= 10) {
            Spaceship.GetComponent<ItemCollector>().DecreaseBribe(10);
            Spaceship.GetComponent<SpaceshipScript>().bribedAlien = true;
            nextScene = true;
            nextSceneId = 4;
        }
    }

    public void ExitToSafeZone()
    {
        nextScene = true;
        nextSceneId = 3;
    }
}
