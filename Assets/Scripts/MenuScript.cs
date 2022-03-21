using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    public void StartGame()
    { 
        SceneManager.LoadScene("Level1");
    }

    public void ToLevelsMenu()
    {
        SceneManager.LoadScene("LevelScene");
    }


    public void QuitGame()
    {
        Application.Quit();
        //временная строка для проверки игры
        PlayerPrefs.SetInt("levels", 1);
    }
}