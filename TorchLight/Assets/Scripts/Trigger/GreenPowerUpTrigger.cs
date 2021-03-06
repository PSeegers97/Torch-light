﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPowerUpTrigger : MonoBehaviour
{
    bool isTriggerActive = false;
    public MeshRenderer myMesh;
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
        myMesh.enabled = false;
        isTriggerActive = false;
        PlayerManager.greenPowerup = true;
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(5);
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
