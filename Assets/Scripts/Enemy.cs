using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _direction;

    private void Update()
    {
        transform.position += _direction * Time.deltaTime;
    }
    
    public void Direction(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
