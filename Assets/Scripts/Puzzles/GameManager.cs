using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject wordButton in GameObject.FindGameObjectsWithTag("WordButton"))
        {
            Button btn = wordButton.GetComponent<Button>();
            btn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
