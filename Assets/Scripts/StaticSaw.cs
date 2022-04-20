using UnityEngine;

public class StaticSaw : Saw
{
    private void FixedUpdate()
    {
        Rotate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KillHeroAndRestartLevel();
        }
    }
}