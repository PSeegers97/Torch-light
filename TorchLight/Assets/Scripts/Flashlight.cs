using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool flashlightEnabled=true;
    
    public GameObject myLightGO;
    public Light mylight;
    
    // Start is called before the first frame update
    void Start()
    {
        mylight.color = Color.white;

    }

    // Update is called once per frame

    void FlashlightbuttonPressed() {

        if (PlayerManager.redPowerup)
        {
         
            if (mylight.color == Color.red && !flashlightEnabled)
            {
                mylight.color = Color.white;
                flashlightEnabled = true;
              
            }
            else if (mylight.color == Color.red && flashlightEnabled)
            {
                flashlightEnabled = false;
              

            }
            else    if (mylight.color == Color.white)
                {
                    mylight.color = Color.red;
                    flashlightEnabled = true;
              
            }

        }
        else if(!PlayerManager.redPowerup)
        {
            flashlightEnabled = !flashlightEnabled;
           

        }
        if (!flashlightEnabled)
        {
            myLightGO.SetActive(false);
           
        }
        else if(flashlightEnabled)
        {
            myLightGO.SetActive(true);
            
        }
    }


    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.P))
        {
            FlashlightbuttonPressed();
            


            
        }
        }
    }


