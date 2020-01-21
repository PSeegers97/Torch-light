using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myCanvas;
    void Start()
    {
        Invoke("disableCanvas", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void disableCanvas()
    {
        myCanvas.SetActive(false);

    } 
}
