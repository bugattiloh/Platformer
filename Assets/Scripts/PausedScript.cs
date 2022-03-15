using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedScript : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    void Start()
    {
        pause.SetActive(false);
    }

    private void PausedOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    private void PausedOn()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale.Equals(1))
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