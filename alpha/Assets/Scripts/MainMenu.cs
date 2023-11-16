using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("My Game");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
