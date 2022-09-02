using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private HashSet<Rigidbody> _affectedBodies = new HashSet<Rigidbody>();
    private Rigidbody _componentRigidbody;

    private void Start()
    {
        _componentRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            _affectedBodies.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            _affectedBodies.Remove(other.attachedRigidbody);
        }
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody body in _affectedBodies)
        {
            Vector3 forceDirection = (transform.position - body.position).normalized;
            float distanceSqr = (transform.position - body.position).sqrMagnitude;
            float strength = _componentRigidbody.mass * body.mass / distanceSqr / 10;

            body.AddForce(forceDirection * strength);
        }
    }
}