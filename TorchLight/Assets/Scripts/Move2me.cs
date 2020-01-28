using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2me : MonoBehaviour
{
    public Transform myParent;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.transform;
       // Debug.Log("Test");
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position.Set(myParent.position.x+90, myParent.position.y, myParent.position.z);
     
    }
}
