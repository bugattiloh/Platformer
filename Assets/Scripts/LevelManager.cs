using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int levelsOpened;

    public Button[] buttons;

    private void Start()
    {
        levelsOpened = PlayerPrefs.GetInt("levels", 1);

        foreach (var button in buttons)
        {
            button.interactable = false;
        }

        for (var i = 0; i < levelsOpened; i++)
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
        SceneManager.LoadScene("Menu");
    }

    protected static void UnlockNextLevel()
    {
        var currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
    }
}