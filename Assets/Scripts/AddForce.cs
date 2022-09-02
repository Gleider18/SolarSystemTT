using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] private Vector3 force;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(force);
    }
}
