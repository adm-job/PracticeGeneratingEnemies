using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed = 10000f;

    private int _currentPointIndex = 0;

    private void Start()
    {
        StartCoroutine(MovePoint());
    }

    private IEnumerator MovePoint()
    {

        while (enabled)
        {
            Transform targetPoint = _points[_currentPointIndex];
            float distance = 0.1f;

            while (Vector3.Distance(transform.position, targetPoint.position) > distance)
            {
                transform.position = Vector3.MoveTowards(
                transform.position,
                targetPoint.position,
                _speed * Time.deltaTime
                );

                yield return null;
            }

            _currentPointIndex = (_currentPointIndex + 1) % _points.Length;


            yield return new WaitForSeconds(2f);
        }
    }

}
