using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopTextScript : MonoBehaviour
{
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Shop";
        // text.icon = null;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Shop";   
    }
}
