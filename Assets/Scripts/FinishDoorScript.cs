using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishDoorScript : LevelManager
{
    public CoinManager coinManager;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        coinManager.Finish();
        UnlockNextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}