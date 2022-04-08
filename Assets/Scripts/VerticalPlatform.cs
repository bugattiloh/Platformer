using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField] private float speed;


    private bool _isUpDirection = true;
    private bool _canMove;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canMove = true;
        }

        if (collision.CompareTag("Point") || collision.CompareTag("Ground"))
        {
            _isUpDirection = !_isUpDirection;
        }
    }


    private void Move()
    {
        Vector3 direction;
        if (_isUpDirection)
        {
            direction = Vector3.up * speed;
        }
        else
        {
            direction = -Vector3.up * speed;
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