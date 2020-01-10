using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellphone : MonoBehaviour
{
    public float time = 5.0f;
    public AudioClip audioClip;

    private bool enter;

    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (!active)
            {
                gameObject.GetComponent<AudioSource>().loop = true;
                gameObject.GetComponent<AudioSource>().Play();
                active = true;
            }
            
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) && enter && active)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("TorchLight"))
        {
            enter = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("TorchLight"))
        {
            enter = false;
        }
    }
}
