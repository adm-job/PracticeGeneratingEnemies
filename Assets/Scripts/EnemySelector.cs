using System;
using System.Collections;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    private int _repeatRate = 2;
    
    public event Action SpawnRed;
    public event Action SpawnGreen;
    public event Action SpawnBlue;

    private void Start()
    {
        StartCoroutine(StartCreation());
    }

    private IEnumerator StartCreation()
    {
        WaitForSeconds _delay = new WaitForSeconds(_repeatRate);
        int numberSpawner;
        int maxSpawners = 3;

        while (enabled)
        {
            numberSpawner = UnityEngine.Random.Range(0, maxSpawners );

            switch (numberSpawner)
            {
                case 0:
                    SpawnRed?.Invoke();
                    break;
                case 1:
                    SpawnBlue?.Invoke();
                    break;
                case 2:
                    SpawnGreen?.Invoke();
                    break;
            }

            yield return _delay;
        }
    }
}
