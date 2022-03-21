using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : Enemy
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float speed;

    private bool _isRightDirection= true;


    private void Rotate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    private void Move()
    {
        Vector3 direction;
        if (_isRightDirection)
        {
            direction = Vector3.right * speed;
        }
        else
        {
            direction = -Vector3.right * speed;
        }

        var currentPos = transform.position;
        var targetPos = currentPos + direction;

        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KillHeroAndRestartLevel();
        }

        if (collision.CompareTag("Point"))
        {
            _isRightDirection = !_isRightDirection;
        }
    }
}