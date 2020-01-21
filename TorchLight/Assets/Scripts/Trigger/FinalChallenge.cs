using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChallenge : MonoBehaviour
{
    public Material greenMat;
    public Material redMat;
    bool isActive=false;

    public GameObject[] mySignals;
    public Color[] solution;
           int progress=0;

   
    public AudioSource myaudio;

    public Animator doorAnim;

    private BoxCollider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        
        myCollider = gameObject.GetComponent<BoxCollider>();

      
    }
    private void OnTriggerEnter(Collider other)
    {
        isActive = true;
    }
   
    private void OnTriggerExit(Collider other)
    {
        isActive = false;
    }
    private void Update()
    {
        if (isActive)
        {
            StartCoroutine(checkSignal());
        }
    }


    IEnumerator  checkSignal() {


        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.R))
        {
            
            myCollider.isTrigger = false;

           

                
                    if (PlayerManager.currentLight == solution[progress])
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



            yield return new WaitForSeconds(0.1f);
            //Success
            if (progress == 5)
            {
                doorAnim.SetBool("isOpen_Obj_1",true);
                
               
                myaudio.Play();
                yield return new WaitForSeconds(1);

                gameObject.SetActive(false);
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
 
   
}
