using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnEnemyGreen : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _poolCapacity = 20;
    [SerializeField] private int _poolMaxSize = 20;
    [SerializeField] private PointGeneration _point;
    [SerializeField] private EnemyTarget _target;
    [SerializeField] private Spawner _spawnerManager;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>
            (
            createFunc: () => Instantiate(_enemy),
            actionOnGet: (enemy) => ActivateEnemy(enemy),
            actionOnRelease: (enemy) => enemy.Deactivate(),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void OnEnable()
    {
        _spawnerManager.SpawnGreen += StartOneEnemy;
    }
    private void OnDisable()
    {
        _spawnerManager.SpawnGreen -= StartOneEnemy;
    }

    private void ActivateEnemy(Enemy enemy)
    {
        enemy.Deading += DeactivateEnemy;
        enemy.transform.position = GetPointStart();

        Vector3 direction = GetPointFinish();

        enemy.SetDirection(direction);
        enemy.Activate();
    }

    private void StartOneEnemy()
    {
        _pool.Get();
    }

    private void DeactivateEnemy(Enemy enemy)
    {
        enemy.Deading -= DeactivateEnemy;
        _pool.Release(enemy);
    }

    private Vector3 GetPointStart()
    {
        return _point.transform.position;
    }

    private Vector3 GetPointFinish()
    {
        return _target.transform.position;
    }
}
