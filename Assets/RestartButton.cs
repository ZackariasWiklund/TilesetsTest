using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Om man trycker på restardbutton så loadar scen 0
public class RestartButton : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
  
}
