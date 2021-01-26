using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void onContinue()
    {
        SceneManager.LoadScene(1);
    }

    public void onLevelSelect()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void onExitGame()
    {
        Application.Quit();
    }
}
