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

    public MeshRenderer timerMesh;
    public MeshRenderer buttonMesh;
    public GameObject timerText;

    public GameObject paintingMover;
    public GameObject baumHinweis;
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
            timerMesh.enabled = false;
            buttonMesh.enabled = false;
            timerText.SetActive(false);
            successAudio.Play();
           
            yield return new WaitForSeconds(1);
            openChestAnim.Play();
            yield return new WaitForSeconds(2);
            greenOrbCollider.isTrigger = true;
            transform.parent.gameObject.SetActive(false);
            paintingMover.SetActive(true);
            baumHinweis.SetActive(true);


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
