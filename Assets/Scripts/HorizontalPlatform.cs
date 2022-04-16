using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    [SerializeField] private float speed;


    private bool _isRightDirection = true;
    private bool _canMove;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canMove = true;
        }

        if (collision.CompareTag("Point") || collision.CompareTag("Ground"))
        {
            _isRightDirection = !_isRightDirection;
        }
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

    private void Update()
    {
        if (_canMove)
        {
            Move();
        }
    }
}