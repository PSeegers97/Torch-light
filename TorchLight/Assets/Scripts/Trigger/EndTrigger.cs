using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;
    public float transitionTime = 1f;

     public Light mylight;

    void Start()
    {

    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        
       if(other.name== "MY_OVRPlayerController"||other.name == "OVRPlayerController")
        {
            ChangeScene();

        }
    }

   
    public void ChangeScene()
    {
        PlayerManager.redPowerup = false;
        PlayerManager.greenPowerup = false;
        mylight.color = Color.white;

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
       

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }


    void Update()
    {
        
    }
}
