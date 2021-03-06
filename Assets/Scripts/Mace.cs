using UnityEngine;


public class Mace : Enemy
{
    [SerializeField] private float speed = 3f;
    private bool _isUpMoving;


    private void Move()
    {
        Vector3 direction;
        if (_isUpMoving)
        {
            direction = transform.up * speed;
        }
        else
        {
            direction = -transform.up * speed;
        }

        var currentPos = transform.position;
        var targetPos = currentPos + direction;

        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KillHeroAndRestartLevel();
        }


        if (collision.CompareTag("Point") || collision.CompareTag("Ground"))
        {
            _isUpMoving = !_isUpMoving;
        }
    }

    private void Update()
    {
        Move();
    }
}