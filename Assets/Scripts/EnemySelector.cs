using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    [SerializeField]private List<EnemySpawner> _spawner;

    private void Start()
    {
        StartCoroutine(Creatings());
    }

    private IEnumerator Creatings()
    {
        while (enabled)
        {
            int index = UnityEngine.Random.Range(0, _spawner.Count);
            _spawner[index].StartOneEnemy();
            
            yield return new WaitForSeconds(1);
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
