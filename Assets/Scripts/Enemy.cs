using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Deading;

    private Quaternion _direction;
    private float _rotationSpeed = 85f;
    private float _speed = 5f;
    private bool _isBlock = true;
    private float _minAngle = 0.1f;
    private int _lifeTime = 15;

    private void Update()
    {
        if (_isBlock)
            return;

        Rotate();
        Move();
    }

    private void Rotate()
    {
        if (Quaternion.Angle(transform.rotation, _direction) > _minAngle)
        {
            transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _direction,
            _rotationSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.rotation = _direction;
        }
    }

    private void Move()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        StartCoroutine(StartLifeTime());
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

    private IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);

        Deading?.Invoke(this);
    }
}

