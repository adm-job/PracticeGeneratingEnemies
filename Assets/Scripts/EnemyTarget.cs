using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed = 3f;

    private int _currentPointIndex = 0;

    private void Start()
    {
        StartCoroutine(MovePoint());
    }

    private IEnumerator MovePoint()
    {
        yield return new WaitForSeconds(2);

        Transform targetPoint = _points[_currentPointIndex];

        Vector3 direction = targetPoint.position - transform.position;
        direction.y = 0;

        transform.position = Vector3.MoveTowards(
        transform.position,
        _points[_currentPointIndex].position,
        _speed * Time.deltaTime
    );

        if (Vector3.Distance(transform.position, _points[_currentPointIndex].position) < 0.1f)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _points.Length;
        }
    }

}
