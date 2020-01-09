using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
     bool isKitchenWardrobedoorLOpen=false;
    bool isKitchenWardrobedoorROpen = false;
    bool isBedroomWardrobedoorLOpen = false;
    bool isBedroomWardrobedoorROpen = false;
     float smoothSpeed=100f;
    // Start is called before the first frame update
    void Start()
    {
     

    }
    private void OnTriggerStay(Collider other)
    {
       
        checkWhichEvent(other);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void checkWhichEvent(Collider other)
    {
        

        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R))
        {


            if (this.name == "KitchenWardrobedoorLTrigger")
            {

                if (!isKitchenWardrobedoorLOpen)
                {


                    this.transform.parent.Rotate(new Vector3(0, -90, 0), Space.Self);
                    isKitchenWardrobedoorLOpen = !isKitchenWardrobedoorLOpen;
                }
                else
                {
                    this.transform.parent.Rotate(new Vector3(0, 90, 0), Space.Self);
                    isKitchenWardrobedoorLOpen = !isKitchenWardrobedoorLOpen;
                }
            }
            else if (this.name == "KitchenWardrobedoorRTrigger")
            {
                if (!isKitchenWardrobedoorROpen)
                {
                    this.transform.parent.Rotate(0, 90.0f, 0, Space.Self);
                    isKitchenWardrobedoorROpen = !isKitchenWardrobedoorROpen;
                }
                else
                {
                    this.transform.parent.Rotate(0, -90.0f, 0, Space.Self);
                    isKitchenWardrobedoorROpen = !isKitchenWardrobedoorROpen;
                }
            }
            else if(this.name == "BedroomWardrobedoorLTrigger")
            {

                if (!isBedroomWardrobedoorLOpen)
                {


                    this.transform.parent.Rotate(new Vector3(0, -90, 0), Space.Self);
                    isBedroomWardrobedoorLOpen = !isBedroomWardrobedoorLOpen;
                }
                else
                {
                    this.transform.parent.Rotate(new Vector3(0, 90, 0), Space.Self);
                    isBedroomWardrobedoorLOpen = !isBedroomWardrobedoorLOpen;
                }
            }
            else if (this.name == "BedroomWardrobedoorRTrigger")
            {
                if (!isBedroomWardrobedoorROpen)
                {
                    this.transform.parent.Rotate(0, 90.0f, 0, Space.Self);
                    isBedroomWardrobedoorROpen = !isBedroomWardrobedoorROpen;
                }
                else
                {
                    this.transform.parent.Rotate(0, -90.0f, 0, Space.Self);
                    isBedroomWardrobedoorROpen = !isBedroomWardrobedoorROpen;
                }
            }
            else if (this.name == "PFB_TVTrigger")
            {
                this.GetComponentInParent<AudioSource>().Play();
               
            }
            else if (this.name == "RoterOrbTrigger")
            {
                PlayerManager.redPowerup = true;
                Destroy(this.transform.parent);
            }
            else if (this.name == "FireplaceTrigger")
            {
               if( other.GetComponent<Light>().color == Color.red){
                   this.transform.parent.Find("KaminFeuer").gameObject.SetActive(true);
                    Destroy(this);
                }
                
            }



        }
    }
}

