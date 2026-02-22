using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Quaternion _direction;
    private float _rotationSpeed = 85f;
    private float _speed = 5f;
    private bool _isRotating = true;
    private bool _isBlock =  true;

    private void Update()
    {
        if(_isBlock)
            return;

        if (_isRotating)
        {
            Rotate();
        }
        else
        {
            Move();
        }
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _direction,
            _rotationSpeed * Time.deltaTime
        );

        if (Quaternion.Angle(transform.rotation, _direction) < 0.1f)
        {
            transform.rotation = _direction;
            _isRotating = false;
        }
    }

    private void Move()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = Quaternion.LookRotation(direction);

        _isBlock = false;
    }
}

