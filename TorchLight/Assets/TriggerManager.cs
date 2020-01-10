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
       
       StartCoroutine( checkWhichEvent(other));
    }
    // Update is called once per frame
    void Update()
    {

    }
    
    IEnumerator checkWhichEvent(Collider other)
    {

        Debug.Log(this.name);
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R))
        {

            if (this.name == "RoterOrbTrigger")
            {
                Debug.Log(isKitchenWardrobedoorLOpen + " as  " + isKitchenWardrobedoorROpen);
             
                
                    Debug.Log("es klappt");
                    PlayerManager.redPowerup = true;

                    this.GetComponent<BoxCollider>().isTrigger = false;
               
               
                
            }
            else if (this.name == "KitchenWardrobedoorLTrigger")
            {

                if (!isKitchenWardrobedoorLOpen)
                {


                    this.transform.parent.Rotate(new Vector3(0, -90, 0), Space.Self);
                    isKitchenWardrobedoorLOpen = !isKitchenWardrobedoorLOpen;
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
                else
                {
                    this.transform.parent.Rotate(new Vector3(0, 90, 0), Space.Self);
                    isKitchenWardrobedoorLOpen = !isKitchenWardrobedoorLOpen;
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else if (this.name == "KitchenWardrobedoorRTrigger")
            {
                if (!isKitchenWardrobedoorROpen)
                {
                    this.transform.parent.parent.Find("RoterOrb").gameObject.SetActive(true);
                    this.transform.parent.Rotate(0, 90.0f, 0, Space.Self);
                    isKitchenWardrobedoorROpen = !isKitchenWardrobedoorROpen;
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;

                }
                else
                {
                    this.transform.parent.Rotate(0, -90.0f, 0, Space.Self);
                    isKitchenWardrobedoorROpen = !isKitchenWardrobedoorROpen;
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else if (this.name == "BedroomWardrobedoorLTrigger")
            {

                if (!isBedroomWardrobedoorLOpen)
                {


                    this.transform.parent.parent.Rotate(new Vector3(0, 90, 0), Space.Self);
                    isBedroomWardrobedoorLOpen = !isBedroomWardrobedoorLOpen;
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
                else
                {
                    this.transform.parent.parent.Rotate(new Vector3(0, -90, 0), Space.Self);
                    isBedroomWardrobedoorLOpen = !isBedroomWardrobedoorLOpen;
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else if (this.name == "BedroomWardrobedoorRTrigger")
            {
                if (!isBedroomWardrobedoorROpen)
                {
                    this.transform.parent.parent.Rotate(0, -90.0f, 0, Space.Self);
                    isBedroomWardrobedoorROpen = !isBedroomWardrobedoorROpen;
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
                else
                {
                    this.transform.parent.parent.Rotate(0, 90.0f, 0, Space.Self);
                    isBedroomWardrobedoorROpen = !isBedroomWardrobedoorROpen;
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else if (this.name == "PFB_TVTrigger")
            {
                this.GetComponentInParent<AudioSource>().Play();

            }
          
            
            else if (this.name == "FireplaceTrigger")
            {
               if( other.GetComponent<Light>().color == Color.red){
                   this.transform.parent.Find("KaminFeuer").gameObject.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                
            }



        }
       
    }
}

