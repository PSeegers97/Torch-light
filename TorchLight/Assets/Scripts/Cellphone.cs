using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellphone : MonoBehaviour
{
    public float time = 5.0f;
    public AudioClip audioClip;

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
            Debug.Log("Actual time: "+time);
        }
        else
        {
            if (!active)
            {
                gameObject.GetComponent<AudioSource>().loop = true;
                gameObject.GetComponent<AudioSource>().Play();
                Debug.Log("Ring");
                active = true;
            }
            
        }

    }

    IEnumerator playRing()
    {
        gameObject.GetComponent<AudioSource>().Play();
        
        yield return new WaitForSeconds(2);
    }
}
