using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _poolCapacity = 20;
    [SerializeField] private int _poolMaxSize = 20;
    [SerializeField] private float _repeatRate = 2f;
    [SerializeField] private GameObject point;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>
            (
            createFunc: () => Instantiate(_enemy),
            actionOnGet: (enemy) => GetOnAction(enemy),
            actionOnRelease: (enemy) => ReleaseEnemy(enemy),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );

    }

    private void GetOnAction(Enemy enemy)
    {
        enemy.transform.position = point.transform.position;
        enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 359f), 0);
        enemy.Activate();
    }

    private void Start()
    {
        StartCoroutine(StartCreation());
    }

    private void ReleaseEnemy(Enemy enemy)
    {
        enemy.Deactivate();
        _pool.Release(enemy);
    }

    private IEnumerator StartCreation()
    {
        float minAndle = 0f;
        float maxAndle = 360f;
        Vector3 position = point.transform.position;

        while (true)
        {
            Quaternion randomAngle = Quaternion.Euler(0, Random.Range(minAndle, maxAndle), 0);
            Instantiate(_enemy, position, randomAngle);
            yield return new WaitForSeconds(_repeatRate);
        }
    }
}
