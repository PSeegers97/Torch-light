using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject fire;
    public GameObject fridgeMover;

    public GameObject timer;
    bool isTriggerActive = false;

    public GameObject summeHinweis;
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
        if (PlayerManager.currentLight == Color.red)
        {
            GetComponent<BoxCollider>().isTrigger = false;

            fire.SetActive(true);
            this.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(3);
            fridgeMover.SetActive(true);
            summeHinweis.SetActive(true);
            timer.SetActive(true);
      

            this.gameObject.SetActive(false);
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
