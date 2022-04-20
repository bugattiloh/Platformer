using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePausedManager : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    private void Start()
    {
        pause.SetActive(false);
    }

    public void PausedOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    private void PausedOn()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausedOn();
        }
    }


    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}