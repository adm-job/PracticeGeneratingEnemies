using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Enemy : MonoBehaviour
{
    public Rigidbody Rigidbody {  get; private set; }
    public CapsuleCollider Capsule { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Capsule = GetComponent<CapsuleCollider>();
    }
    
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
