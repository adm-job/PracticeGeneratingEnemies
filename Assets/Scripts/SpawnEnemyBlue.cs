using UnityEngine;

public class SpawnEnemyBlue : SpawnEnemy
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _enemySelector.SpawnBlue += StartOneEnemy;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _enemySelector.SpawnBlue -= StartOneEnemy;
    }

}
