using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject fire;
    public GameObject fridgeMover;
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
        if (PlayerManager.currentLight == Color.red)
        {

            fire.SetActive(true);
            this.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2);
            fridgeMover.SetActive(true);

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
