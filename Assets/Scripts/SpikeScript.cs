using UnityEngine;


public class SpikeScript : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KillHeroAndRestartLevel();
        }
    }
}