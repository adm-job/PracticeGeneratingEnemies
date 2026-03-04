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
}
