using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    protected static void KillHeroAndRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}