using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour
{
    public void onLevelSelect(Button button) {
        SceneManager.LoadScene(button.name);
    }
}
