using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool flashlightEnabled=true;
    
    public GameObject mylight;
    // Start is called before the first frame update
    void Start()
    {
        print(OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).x);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Back))
        {
             
            flashlightEnabled =  !flashlightEnabled;
            
        
        if (flashlightEnabled==true ) {
                mylight.SetActive(true);
               
        }
        else if(flashlightEnabled==false)
        {
                mylight.SetActive(false);
        }
        }
    }
}

