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

    private List<EnemySpawner> _spawner;
    private EnemySpawner _enemySpawner1;
    private EnemySpawner _enemySpawner2;
    private EnemySpawner _enemySpawner3;

    private void Start()
    {
        //StartCoroutine(StartCreation());
        //_spawner.Add(_enemySpawner1);
        //_spawner.Add(_enemySpawner2);
        //_spawner.Add(_enemySpawner3);
        EnemySpawner[] enemySpawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);
        //_spawner.AddRange(enemySpawners);
        _spawner = new List<EnemySpawner>(enemySpawners);
        
        StartCoroutine(Creatings());
    }

    private IEnumerator Creatings()
    {

        while (enabled)
        {
            yield return new WaitForSeconds(1);
            _spawner[0].StartOneEnemy();
            _spawner[1].StartOneEnemy();
            _spawner[2].StartOneEnemy();
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
