using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    //private int _repeatRate = 2;

    //public event Action Generating;
    //public event Action SpawnGreen;
    //public event Action SpawnBlue;

    private List<EnemySpawner> _spawned;
    private EnemySpawner _enemySpawner1;
    private EnemySpawner _enemySpawner2;
    private EnemySpawner _enemySpawner3;

    private void Start()
    {
        //StartCoroutine(StartCreation());
        StartCoroutine(Creatings());
        _spawned.Add(_enemySpawner1);
        _spawned.Add(_enemySpawner2);
        _spawned.Add(_enemySpawner3);
    }

    private IEnumerator Creatings()
    {

        while (enabled)
        {
            yield return new WaitForSeconds(1);
            _spawned[0].StartOneEnemy();
            _spawned[1].StartOneEnemy();
            _spawned[2].StartOneEnemy();
        }
    }

    //private IEnumerator StartCreation()
    //{
    //    WaitForSeconds _delay = new WaitForSeconds(_repeatRate);
    //    int numberSpawner;
    //    int maxSpawners = 3;

    //    while (enabled)
    //    {
    //        numberSpawner = UnityEngine.Random.Range(0, maxSpawners);

    //        switch (numberSpawner)
    //        {
    //            case 0:
    //                SpawnRed?.Invoke();
    //                break;
    //            case 1:
    //                SpawnBlue?.Invoke();
    //                break;
    //            case 2:
    //                SpawnGreen?.Invoke();
    //                break;
    //        }

    //        yield return _delay;
    //    }

}
