using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected Enemy _enemy;
    [SerializeField] protected int _poolCapacity = 20;
    [SerializeField] protected int _poolMaxSize = 20;
    [SerializeField] protected PointGeneration _point;
    [SerializeField] protected EnemyTarget _target;
    [SerializeField] protected EnemySelector _enemySelector;

    protected ObjectPool<Enemy> _pool;

    protected void Awake()
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

    //protected virtual void OnEnable()
    //{
    //    _enemySelector.Generating += StartOneEnemy;
    //}
    //protected virtual void OnDisable()
    //{
    //    _enemySelector.Generating -= StartOneEnemy;
    //}

    protected void ActivateEnemy(Enemy enemy)
    {
        enemy.Deading += DeactivateEnemy;
        enemy.transform.position = GetPointStart();

        Vector3 direction = GetPointFinish();

        enemy.SetDirection(direction);
        enemy.Activate();
    }

    public void StartOneEnemy()
    {
        _pool.Get();
    }

    protected void DeactivateEnemy(Enemy enemy)
    {
        enemy.Deading -= DeactivateEnemy;
        _pool.Release(enemy);
    }

    protected Vector3 GetPointStart()
    {
        return _point.transform.position;
    }

    protected Vector3 GetPointFinish()
    {
        return _target.transform.position;
    }
}
