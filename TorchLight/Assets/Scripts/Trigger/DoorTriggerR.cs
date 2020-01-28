using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerR : MonoBehaviour
{
    bool isTriggerActive = false;
    bool isOpen = false;
    public BoxCollider roterOrbCollider;
    public bool isKitchenDoor;
    public GameObject mydoor;
    void Start()
    {

    }


    public void OnTriggerEnter(Collider other)
    {
        isTriggerActive = true;
       
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggerActive = false;
       

    }

    IEnumerator ExecuteTriggerAction()
    {
        if (!isOpen)
        {
           
            mydoor.transform.Rotate(new Vector3(0, 90, 0), Space.Self);
            isOpen = true;
            GetComponentInParent<AudioSource>().Play();
            GetComponent<BoxCollider>().isTrigger = false;

            if (isKitchenDoor)
            {
                yield return new WaitForSeconds(2);
                roterOrbCollider.isTrigger = true;
            }
            yield return new WaitForSeconds(3);
           
            this.GetComponent<BoxCollider>().isTrigger = true;
            

        }
        else
        {
          
            mydoor.transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            isOpen = false;
            this.GetComponentInParent<AudioSource>().Play();
            this.GetComponent<BoxCollider>().isTrigger = false;
            yield return new WaitForSeconds(3);
            this.GetComponent<BoxCollider>().isTrigger = true;

        }

    }


    void Update()
    {
        if (isTriggerActive && (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R)))
        {

            StartCoroutine(ExecuteTriggerAction());
        }
    }
}
