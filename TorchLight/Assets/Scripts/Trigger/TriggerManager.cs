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

     
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R))
        {

            if (this.name == "RoterOrbTrigger")
            {
              
                
                    
                    PlayerManager.redPowerup = true;

                   
                this.transform.parent.gameObject.SetActive(false);
               
               
                
            }
            else if (this.name == "KitchenWardrobedoorLTrigger")
            {

                if (!isKitchenWardrobedoorLOpen)
                {


                    this.transform.parent.Rotate(new Vector3(0, -90, 0), Space.Self);
                    isKitchenWardrobedoorLOpen = !isKitchenWardrobedoorLOpen;
                    this.GetComponentInParent<AudioSource>().Play();
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
                else
                {
                    this.transform.parent.Rotate(new Vector3(0, 90, 0), Space.Self);
                    isKitchenWardrobedoorLOpen = !isKitchenWardrobedoorLOpen;
                    this.GetComponentInParent<AudioSource>().Play();
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else if (this.name == "KitchenWardrobedoorRTrigger")
            {
                if (!isKitchenWardrobedoorROpen)
                {
                    
                    this.transform.parent.Rotate(0, 90.0f, 0, Space.Self);
                    isKitchenWardrobedoorROpen = !isKitchenWardrobedoorROpen;
                    this.GetComponentInParent<AudioSource>().Play();
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.transform.parent.parent.Find("RoterOrb").GetComponentInChildren<BoxCollider>().isTrigger = true;
                    this.GetComponent<BoxCollider>().isTrigger = true;

                }
                else
                {
                    this.transform.parent.Rotate(0, -90.0f, 0, Space.Self);
                    isKitchenWardrobedoorROpen = !isKitchenWardrobedoorROpen;
                    this.GetComponentInParent<AudioSource>().Play();
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
                    this.GetComponentInParent<AudioSource>().Play();
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
                else
                {
                    this.transform.parent.parent.Rotate(new Vector3(0, -90, 0), Space.Self);
                    isBedroomWardrobedoorLOpen = !isBedroomWardrobedoorLOpen;
                    this.GetComponentInParent<AudioSource>().Play();
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
                    this.GetComponentInParent<AudioSource>().Play();
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
                else
                {
                    this.transform.parent.parent.Rotate(0, 90.0f, 0, Space.Self);
                    isBedroomWardrobedoorROpen = !isBedroomWardrobedoorROpen;
                    this.GetComponentInParent<AudioSource>().Play();
                    this.GetComponent<BoxCollider>().isTrigger = false;
                    yield return new WaitForSeconds(3);
                    this.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else if (this.name == "PFB_TVTrigger")
            {
                this.GetComponentInParent<AudioSource>().Play();

            }
            else if (this.name=="RadioTrigger" )
            {
                this.GetComponentInParent<AudioSource>().Play();
            }
            else if (this.name == "PFB_ToiletTrigger")
            {
                this.GetComponentInParent<AudioSource>().Play();
            }
          
            
            else if (this.name == "FireplaceTrigger")
            {
               if( other.GetComponent<Light>().color == Color.red){
                   this.transform.parent.Find("KaminFeuer").gameObject.SetActive(true);
                    this.GetComponent<AudioSource>().Play();
                    GameObject fridgeMover = transform.parent.parent.Find("FridgeParent").Find("PFB_Fridge").Find("FridgeMover").gameObject;
                    yield return new WaitForSeconds(2);
                    fridgeMover.SetActive(true);
                   
                    this.gameObject.SetActive(false);
                }
                

            }
            else if (this.name == "TimerButton")
            {

                if (TimerControl.CheckNumber() == 20)
                {

                    transform.parent.gameObject.GetComponent<AudioSource>().Play();
                    yield return new WaitForSeconds(2);
                    transform.parent.parent.GetComponent<Animation>().Play();
                    
                    yield return new WaitForSeconds(2);
                    this.transform.parent.parent.Find("GreenOrb").Find("GreenOrbTrigger").gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    this.transform.parent.gameObject.SetActive(false);

                }
                else {
                    
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    gameObject.GetComponent<AudioSource>().Play();
                    yield return new WaitForSeconds(3);
                    GetComponent<BoxCollider>().isTrigger = true;

                }

            }
            else if (this.name == "GreenOrbTrigger")
            {
                PlayerManager.greenPowerup = true;
                transform.parent.gameObject.SetActive(false);
            }
            else if (this.name == "TreeTrigger")
            {
                if (other.GetComponent<Light>().color == Color.green)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    transform.Find("HinweisTree").gameObject.SetActive(true);
                    gameObject.SetActive(false);
                }
            }



        }
       
    }
}

