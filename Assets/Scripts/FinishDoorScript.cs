using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class FinishDoorScript : LevelManager
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNextLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // private static void UnlockNextLevel()
    // {
    //     var currentLevel = SceneManager.GetActiveScene().buildIndex;
    //
    //     if (currentLevel >= PlayerPrefs.GetInt("levels"))
    //     {
    //         PlayerPrefs.SetInt("levels", currentLevel + 1);
    //     }
    // }
}