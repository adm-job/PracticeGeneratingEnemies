using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Quaternion _direction;
    private float _rotationSpeed = 5f;
    private float _speed = 5f;

    public void SetDirection(Quaternion direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if (transform.rotation != _direction)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _direction, _rotationSpeed * 360f * Time.deltaTime);
        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * _speed;
        }
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
