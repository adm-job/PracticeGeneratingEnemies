using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _poolCapacity = 20;
    [SerializeField] private int _poolMaxSize = 20;
    [SerializeField] private float _repeatRate = 2f;
    [SerializeField] private PointGeneration[] points;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>
            (
            createFunc: () => Instantiate(_enemy),
            actionOnGet: (enemy) => ActivatingEnemy(enemy),
            actionOnRelease: (enemy) => ReturnEnemy(enemy),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void ActivatingEnemy(Enemy enemy)
    {
        enemy.transform.position = GetRandomPoint();
        enemy.transform.rotation = GerRandomAngle();

        Vector3 direction = GetRandomDirection(); 

        enemy.Direction(direction);
        enemy.Activate();
    }

    private void Start()
    {
        StartCoroutine(StartCreation());
    }

    private IEnumerator StartCreation()
    {
        WaitForSeconds _delay = new WaitForSeconds(_repeatRate);

        while (enabled)
        {
            _pool.Get();

            yield return _delay;
        }
    }

    private void ReturnEnemy(Enemy enemy)
    {
        enemy.Deactivate();
        _pool.Release(enemy);
    }

    private Vector3 GetRandomPoint()
    {
        return points[Random.Range(0, points.Length)].transform.position;
    }

    private Quaternion GerRandomAngle()
    {
        float minAngle = 0f;
        float maxAngle = 360f;

        return Quaternion.Euler(0, Random.Range(minAngle, maxAngle), 0);
    }
    
    private Vector3 GetRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        return new Vector3(x, 0, z).normalized;
    }
}
