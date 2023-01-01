using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void quit()
    {
        Application.Quit();
    }



}
