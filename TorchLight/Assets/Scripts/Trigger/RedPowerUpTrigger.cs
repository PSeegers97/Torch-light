using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPowerUpTrigger : MonoBehaviour
{
    bool isTriggerActive = false;
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
        isTriggerActive = false;
        PlayerManager.redPowerup = true;
        GetComponent<AudioSource>().Play();
        
        yield return new WaitForSeconds(1);
        transform.parent.gameObject.SetActive(false);



    }


    void Update()
    {
        if (isTriggerActive && (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R)))
        {

            StartCoroutine(ExecuteTriggerAction());
        }
    }
}
