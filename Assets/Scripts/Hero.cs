using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 0.1f;
    private bool _isGrounded;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public enum States
    {
        idle = 0,
        run = 1
    }

    private States State
    {
        get { return (States)_animator.GetInteger("state"); }
        set { _animator.SetInteger("state", (int) value); }
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }


    private bool GetFlipX(Vector3 direction)
    {
        if (direction.x < 0.0f)
        {
            return true;
        }

        return false;
    }

    private void Run()
    {
        
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        Vector3 currentPos = transform.position;
        Vector3 targetPos = currentPos + direction;

        _spriteRenderer.flipX = GetFlipX(direction);
        if (_isGrounded)
        {
            State = States.run;
        }

        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isGrounded)
        {
            State = States.idle;
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        Collider2D[] colliiders = Physics2D.OverlapCircleAll(transform.position, 1f);
        if (colliiders.Length > 1)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}