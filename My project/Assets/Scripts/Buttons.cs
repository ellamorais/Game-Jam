using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void changetoMainScene()
    {
        SceneManager.LoadScene("main");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
