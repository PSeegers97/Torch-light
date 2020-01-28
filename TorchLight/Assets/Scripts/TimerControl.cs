using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerControl : MonoBehaviour
{

    public static int timerNumber;
    public TextMeshPro myText;
    // Start is called before the first frame update
    void Start()
    {
        timerNumber = 30;
        InvokeRepeating("ChangeTimer", 1f, 1f);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static int CheckNumber()
    {
        return timerNumber;
    }
    public void ChangeTimer()
    {

        if(timerNumber != 0)
        {
            timerNumber--;
        }
        else
        {
            timerNumber = 30;
        }
        myText.text = timerNumber+"";

    }
}
