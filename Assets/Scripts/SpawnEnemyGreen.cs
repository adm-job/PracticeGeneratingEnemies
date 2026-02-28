using UnityEngine;

public class SpawnEnemyGreen : SpawnEnemy
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _enemySelector.SpawnGreen += StartOneEnemy;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _enemySelector.SpawnGreen -= StartOneEnemy;
    }
}
