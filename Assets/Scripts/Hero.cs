using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool _isGrounded;
    private bool _godMode = false;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public Transform GroundCheck;
    public float checkRadius = 0.15f;
    public LayerMask Ground;

    private enum States
    {
        Idle = 0,
        Run = 1,
        Jump = 2,
    }


    private States State
    {
        set => _animator.SetInteger("state", (int) value);
    }


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (CheckFall())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

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

        if (Input.GetKeyDown(KeyCode.G))
        {
            GodModeSwitch();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Run()
    {
        var direction = transform.right * Input.GetAxis("Horizontal");
        var currentPos = transform.position;
        var targetPos = currentPos + direction;

        _spriteRenderer.flipX = ShouldFlipX(direction);
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
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        if (!_isGrounded)
        {
            State = States.Jump;
        }
    }


    private static bool ShouldFlipX(Vector3 direction)
    {
        return direction.x < 0.0f;
    }

    private bool CheckFall()
    {
        return _rigidBody.position.y < -40;
    }

    private void GodModeSwitch()
    {
        if (!_godMode)
        {
            transform.gameObject.tag = "Untagged";
        }
        else
        {
            transform.gameObject.tag = "Player";
        }

        _godMode = !_godMode;
    }
}