using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mylight;
    float counter=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
    }
    public void OnTriggerStay(Collider other)
    {
        counter+= Time.deltaTime;
        
        if (counter > 3) {
            if (!mylight.activeSelf) { 
            mylight.SetActive(true);
                PlayerManager.redPowerup = true;
              
            }
           
        }
    }
    void Update()
    {
        
    }
}
