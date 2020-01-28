using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectSlow : MonoBehaviour
{
    public float lerptime= 5;
    private float currentlerptime;
    private Vector3 startPos;
    private Vector3 endPos;
    public Vector3 direction;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
     
        startPos = transform.parent.position;
        endPos=transform.parent.position+ direction*distance;
}

    // Update is called once per frame
    void Update()
    {
        currentlerptime += Time.deltaTime;
        if(currentlerptime >= lerptime)
        {
            currentlerptime = lerptime;
        }
        float perc = currentlerptime / lerptime;
        transform.parent.position = Vector3.Lerp(startPos, endPos, perc);
    }
    
}
