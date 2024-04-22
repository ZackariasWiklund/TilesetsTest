using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    
    private void Start()
    {


    }

    void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Animator>().Play("Door"); // Trigger the animation
            
            other.gameObject.GetComponent<PlayerController>().enabled = false;

            other.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }


}

