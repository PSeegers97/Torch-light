using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mylight;
    float counter=0;
    public GameObject frontDoor;
    public GameObject flashlightColor;
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
                PlayerManager.redPowerup = true;
                 mylight.SetActive(true);
                frontDoor.transform.Rotate(0, 90.0f, 0, Space.Self);
                Destroy(this);
              
            }
           
        }
    }
    void Update()
    {
        
    }
}
