using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButtonTrigger : MonoBehaviour
{
    bool isTriggerActive = false;
    public AudioSource successAudio;
    public AudioSource errorAudio;

    public Animation openChestAnim;
    public BoxCollider greenOrbCollider;
    void Start()
    {

    }

    // Update is called once per frame
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

        if (TimerControl.CheckNumber() == 20) {
            successAudio.Play();
           
            yield return new WaitForSeconds(2);
            openChestAnim.Play();
            yield return new WaitForSeconds(2);
            greenOrbCollider.isTrigger = true;
            transform.parent.gameObject.SetActive(false);


        }
        else{
            GetComponent<BoxCollider>().isTrigger = false;
            errorAudio.Play();
            yield return new WaitForSeconds(3);
            GetComponent<BoxCollider>().isTrigger = true;
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
