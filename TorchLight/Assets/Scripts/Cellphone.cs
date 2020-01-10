using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellphone : MonoBehaviour
{
    public float time = 5.0f;
    public AudioClip laughClip;
    private AudioSource source;

    private bool hasPlayed;

    private bool enter;

    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        hasPlayed = false;
        source = gameObject.GetComponent<AudioSource>();
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
                source.loop = true;
                source.Play();
                active = true;
            }
            
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) && enter && active)
        {
            source.Stop();
            StartCoroutine(startSoundAfterRing());
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

    IEnumerator startSoundAfterRing() {

        if (!hasPlayed)
        {
            source.clip = laughClip;
            source.loop = false;
            source.Play();
            yield return new WaitForSeconds(source.clip.length);
            source.Stop();
            hasPlayed = true;
        }
    }
}
