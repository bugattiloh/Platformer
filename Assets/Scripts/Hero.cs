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
        Idle = 0,
        Run = 1,
        Jump = 2,
    }


    private States State
    {
        get { return (States) _animator.GetInteger("state"); }
        set { _animator.SetInteger("state", (int) value); }
    }


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (_isGrounded)
        {
            State = States.Idle;
        }

        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        Vector3 currentPos = transform.position;
        Vector3 targetPos = currentPos + direction;

        _spriteRenderer.flipX = ShouldFlipX(ref direction);
        if (_isGrounded)
        {
            State = States.Run;
        }

        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.9f);
        if (colliders.Length > 1)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
            State = States.Jump;
        }
    }

    private bool ShouldFlipX(ref Vector3 direction)
    {
        if (direction.x < 0.0f)
        {
            return true;
        }

        return false;
    }
}