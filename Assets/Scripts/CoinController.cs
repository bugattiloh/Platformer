using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public int score;
    public Text scoreCounter;

    private void AddCoin()
    {
        score++;
        scoreCounter.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        AddCoin();
        Destroy(gameObject);
    }
}