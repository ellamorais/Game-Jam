using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour 
{
    Animator anim;
    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void changetoMainScene(string sceneName)
    {
        anim.SetTrigger("Active");
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
