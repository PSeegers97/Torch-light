using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinweisTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hinweisImage;
    public MeshCollider coneCollider;
    bool isTriggerActive = false;
    bool isCanvasActive = false;
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
        coneCollider.enabled = false;
        hinweisImage.SetActive(true);
        isCanvasActive = true;
        yield return new WaitForSeconds(3);
    }
    IEnumerator deactivateCanvas()
    {
        isCanvasActive = false;
        hinweisImage.SetActive(false);
        yield return new WaitForSeconds(2);
        coneCollider.enabled = true;

    }


    void Update()
    {
        if(isCanvasActive && (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R))){

            StartCoroutine(deactivateCanvas());
        }


        if (isTriggerActive && (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R)))
        {
            
            StartCoroutine(ExecuteTriggerAction());
        }
    }
}
