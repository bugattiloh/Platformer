using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaceScript : MonoBehaviour
{
    [SerializeField] private float speed = 1000f;
    private bool _isUpMoving = false;


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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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