using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour {

    public static int Bribe = 0;
    public static int Credits = 0;
    
    [SerializeField] private TMP_Text bribeText;
    [SerializeField] private TMP_Text creditsText;

    private void Start() {
        bribeText.SetText("Bribe: " + Bribe);
        creditsText.SetText("Credits: " + Credits);
    }

    private void Update()
    {
        bribeText.SetText("Bribe: " + Bribe);
        creditsText.SetText("Credits: " + Credits);
    }


    public void IncreaseCredits(int credits) {
        Credits += credits;
    }

    public void DecreaseCredits(int credits) {
        Credits -= credits;
    }

    public void IncreaseBribe(int bribe) {
        Bribe += bribe;
    }
    
    public void DecreaseBribe(int bribe) {
        Bribe -= bribe;
    }
    
}
