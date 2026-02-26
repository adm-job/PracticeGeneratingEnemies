using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Deading;

    private Vector3 _direction;
    private float _speed = 5f;
    private bool _isBlock = true;
    private int _lifeTime = 60;

    private void Update()
    {
        if (_isBlock)
            return;

        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _direction,
            _speed * Time.deltaTime
            );
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
        _direction = direction;

        _isBlock = false;
    }

    private IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);

        Deading?.Invoke(this);
    }
}

