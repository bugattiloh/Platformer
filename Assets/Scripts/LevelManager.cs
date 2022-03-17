using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int levelsOpened;

    public Button[] buttons;

    void Start()
    {
        levelsOpened = PlayerPrefs.GetInt("levels", 1);

        foreach (var t in buttons)
        {
            t.interactable = false;
        }
        for ( int i = 0; i < levelsOpened; i++)
        {
            buttons[i].interactable = true;
        }
    }
    

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}