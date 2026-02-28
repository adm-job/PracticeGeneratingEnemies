using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed = 5f;
    private int _lifeTime = 60;

    public event Action<Enemy> Deading;

    private void Update()
    {
        if (_direction == null)
            return;

        Move();
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
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _direction,
            _speed * Time.deltaTime
            );
    }

    private IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);

        Deading?.Invoke(this);
    }
}

