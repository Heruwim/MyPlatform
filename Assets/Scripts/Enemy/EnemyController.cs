using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _relativePosition;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + _relativePosition;
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        if(_rotationSpeed > 0)
        {
            transform.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
        }
    }

    private void Move()
    {
        if (_speed > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed * Time.deltaTime);
            if (transform.position == _endPosition)
            {
                _endPosition = _startPosition;
                _startPosition = transform.position;
            }
        }
    }
}
