using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaceScript : Enemy
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

        Vector3 currentPos = transform.position;
        Vector3 targetPos = currentPos + direction;

        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KillHeroAndRestartLevel();
        }

        if (collision.CompareTag("Ground"))
        {
            _isUpMoving = true;
        }

        if (collision.CompareTag("Point"))
        {
            _isUpMoving = false;
        }
    }

    void Update()
    {
        Move();
    }
}