using System.Collections;
using System.Collections.Generic;
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
}
