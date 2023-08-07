using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4;
    [SerializeField] private float _jumpSpeed = 7;

    private Rigidbody2D _body;
    private Animator _animator;
    private bool _isLeftMovement;
    private bool _isRunning;
    private bool _isJumping;
    private bool _isGameOvered;
    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        Jump();
        SwichAnimation();
    }    

    private void Move()
    {
        var horizontalMovement = Input.GetAxisRaw("Horizontal");
        if(horizontalMovement != 0)
        {
            _isRunning = true;
            _body.position += new Vector2(horizontalMovement * _moveSpeed * Time.deltaTime, 0);
            if(horizontalMovement > 0 && _isLeftMovement || horizontalMovement < 0 && !_isLeftMovement)
            {
                var scale = transform.localScale;
                scale.x *= -1;

                transform.localScale = scale;
                _isLeftMovement = !_isLeftMovement;
            }
        }
        else
        {
            _isRunning= false;
        }
    } 

    private void Jump()
    {
        var jump = Input.GetKeyDown(KeyCode.Space);

        if (jump && IsGrounded())
        {
            _isJumping = true;
            _body.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        var raycast = Physics2D.Raycast(transform.position - transform.localScale / 2, Vector2.down, 0.1f);
        return raycast.collider != null;
    }

    private void SwichAnimation()
    {
       
        if (_isJumping)
        {
            if (_body.velocity.y > 0)
            {
                _animator.SetTrigger("ToUp");
            }
            else
            {
                _animator.SetTrigger("ToDown");
            }            
        }
        else if (_isRunning)
        {
            _animator.SetTrigger("ToRun");
        }
        else
        {
            _animator.SetTrigger("ToIdle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isJumping= false;

        if(collision.gameObject.tag == "Enemy")
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        if (_isGameOvered)
        {
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
