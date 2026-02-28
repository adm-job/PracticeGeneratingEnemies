using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyRed : SpawnEnemy
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _enemySelector.SpawnRed += StartOneEnemy;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _enemySelector.SpawnRed -= StartOneEnemy;
    }
}
