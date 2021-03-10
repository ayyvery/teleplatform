using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public Text levelID;
    
    private void Start() {
        levelID.text = PlayerPrefs.GetInt("level", 1).ToString();
    }
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
