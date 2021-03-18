using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class levelSelect : MonoBehaviour
{
    public GameObject[] buttons = new GameObject[12];

    private void Start() {
        int level = PlayerPrefs.GetInt("level", 1);

        for(int i = 11; i > level; i = i - 1) {
            buttons[i].SetActive(false);
        }
    }

    public void onLevelSelect(Button button) {
        SceneManager.LoadScene(button.name);
    }

    public void onBackToMenu() {
        SceneManager.LoadScene("menu");
    }
}