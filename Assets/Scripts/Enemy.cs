using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime;
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
