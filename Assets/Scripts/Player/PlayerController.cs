using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _jumpSpeed = 7;

    private Rigidbody2D _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        Jump();
    }    

    private void Move()
    {
        var horizontalMovement = Input.GetAxisRaw("Horizontal");
        if(horizontalMovement != 0)
        {
            _body.position += new Vector2(horizontalMovement * _moveSpeed * Time.deltaTime, 0); 
        }
    } 

    private void Jump()
    {
        var jump = Input.GetKeyDown(KeyCode.Space);

        if (jump)
        {
            _body.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
        }

    }
}
