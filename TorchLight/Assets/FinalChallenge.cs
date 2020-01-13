using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChallenge : MonoBehaviour
{
    public Material greenMat;
    public Material redMat;

    public GameObject[] mySignals;
    public Color[] solution;
    public int progress=0;

    public GameObject exit;
    public AudioSource myaudio;

    private BoxCollider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        ResetMyArrays();
        myCollider = gameObject.GetComponent<BoxCollider>();

      
    }
    private void OnTriggerStay(Collider other)
    {
        StartCoroutine( checkSignal( other));
    }

    IEnumerator  checkSignal(Collider other) {


        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R))
        {
            
            myCollider.isTrigger = false;

           

                
                    if (other.gameObject.GetComponent<Light>().color == solution[progress])
                    {
                mySignals[progress].GetComponent<Renderer>().material = greenMat;

                progress++;
                     
                        
                    }
                    else
                    {
                   
                    progress = 0;
                             for (int i = 0; i < 5; i++)
                             {


                              mySignals[i].GetComponent<Renderer>().material = redMat;


                                }

            }



            yield return new WaitForSeconds(1);
            if (progress == 5)
            {
                gameObject.SetActive(false);
                exit.transform.Rotate(0, 90, 0);
                myaudio.Play();
            }
            myCollider.isTrigger = true;

        }
    }

    public void ChangeMaterial()
    {
        for (int i = 0; i < progress; i++)
        {


            mySignals[i].GetComponent<Renderer>().material = greenMat;


        }
        for (int k = 0; k < (4-progress); k++) {

            mySignals[k].GetComponent<Renderer>().material = redMat;
        }

    }
    public void ResetMyArrays()
    {
        solution[0] = Color.white;
        solution[1] = Color.red;
        solution[2] = Color.green;
        solution[3] = Color.red;
        solution[4] = Color.white;

        progress = 0;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
