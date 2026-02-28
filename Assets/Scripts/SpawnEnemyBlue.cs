using UnityEngine;

public class SpawnEnemyBlue : SpawnEnemy
{
    //[SerializeField] private Enemy _enemy;
    //[SerializeField] private int _poolCapacity = 20;
    //[SerializeField] private int _poolMaxSize = 20;
    //[SerializeField] private PointGeneration _point;
    //[SerializeField] private EnemyTarget _target;
    //[SerializeField] private EnemySelector _enemySelector;

    //private ObjectPool<Enemy> _pool;

    //private void Awake()
    //{
    //    _pool = new ObjectPool<Enemy>
    //        (
    //        createFunc: () => Instantiate(_enemy),
    //        actionOnGet: (enemy) => ActivateEnemy(enemy),
    //        actionOnRelease: (enemy) => enemy.Deactivate(),
    //        actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
    //        collectionCheck: true,
    //        defaultCapacity: _poolCapacity,
    //        maxSize: _poolMaxSize
    //        );
    //}

    //private void OnEnable()
    //{
    //    _enemySelector.SpawnBlue += StartOneEnemy;
    //}
    //private void OnDisable()
    //{
    //    _enemySelector.SpawnBlue -= StartOneEnemy;
    //}

    //private void ActivateEnemy(Enemy enemy)
    //{
    //    enemy.Deading += DeactivateEnemy;
    //    enemy.transform.position = GetPointStart();

    //    Vector3 direction = GetPointFinish();

    //    enemy.SetDirection(direction);
    //    enemy.Activate();
    //}

    //private void StartOneEnemy()
    //{
    //    _pool.Get();
    //}

    //private void DeactivateEnemy(Enemy enemy)
    //{
    //    enemy.Deading -= DeactivateEnemy;
    //    _pool.Release(enemy);
    //}

    //private Vector3 GetPointStart()
    //{
    //    return _point.transform.position;
    //}

    //private Vector3 GetPointFinish()
    //{
    //    return _target.transform.position;
    //}
}
