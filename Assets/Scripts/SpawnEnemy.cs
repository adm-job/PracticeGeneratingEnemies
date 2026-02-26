using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnEnemy : MonoBehaviour
{
    //[SerializeField] private Enemy _enemy;
    [SerializeField] private int _poolCapacity = 20;
    [SerializeField] private int _poolMaxSize = 20;
    [SerializeField] private float _repeatRate = 2f;
    [SerializeField] private PointGeneration[] _points;
    [SerializeField] private EnemyTarget[] _targets;
    [SerializeField] private Enemy[] _enemies;

    private ObjectPool<Enemy> _pool;
    private int index;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>
            (
            createFunc: () => CreateObject(),
            actionOnGet: (enemy) => ActivateEnemy(enemy),
            actionOnRelease: (enemy) => enemy.Deactivate(),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void Start()
    {
        StartCoroutine(StartCreation());
    }

    private Enemy CreateObject()
    {
       return Instantiate(_enemies[index]);
    }

    private void ActivateEnemy(Enemy enemy)
    {
        enemy.Deading += DeactivateEnemy;
        enemy.transform.position = GetPointsStart();

        Vector3 direction = GetPointsFinish(); 

        enemy.SetDirection(direction);
        enemy.Activate();
    }

    private IEnumerator StartCreation()
    {
        WaitForSeconds _delay = new WaitForSeconds(_repeatRate);


        while (enabled)
        {
            index = Random.Range(0, _enemies.Length);

            _pool.Get();

            yield return _delay;
        }
    }

    private void DeactivateEnemy(Enemy enemy)
    {
        enemy.Deading -= DeactivateEnemy;
        _pool.Release(enemy);
    }

    private Vector3 GetPointsStart()
    {
        return _points[index].transform.position;
    }

    private Vector3 GetPointsFinish()
    {
        return _targets[index].transform.position;
    }
}
