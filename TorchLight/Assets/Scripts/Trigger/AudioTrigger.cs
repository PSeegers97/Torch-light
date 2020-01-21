using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool isTriggerActive = false;
    public AudioSource myAudio;
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
        if (!myAudio.isPlaying)
        {
            myAudio.Play();
        }
        
        yield return new WaitForSeconds(1);
    }


    void Update()
    {
        if (isTriggerActive && (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R)))
        {

            StartCoroutine(ExecuteTriggerAction());
        }
    }
}
