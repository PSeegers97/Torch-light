using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool isTriggerActive = false;
    public AudioSource successAudio;
    public GameObject hinweisText;
    public GameObject letzteEingabe;
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
        if (PlayerManager.currentLight == Color.green)
        {
            successAudio.Play();
            hinweisText.SetActive(true);
            letzteEingabe.SetActive(true);
            yield return new WaitForSeconds(2);
            GetComponent<BoxCollider>().isTrigger = false;
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
