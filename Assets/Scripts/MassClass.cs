using UnityEngine;

public class MassClass : MonoBehaviour
{
    private void Start()
    {
        var componentRigidbody = GetComponent<Rigidbody>();
        var scale = componentRigidbody.mass / 300;
        GetComponent<Transform>().localScale = new Vector3(scale,scale,scale);
    }
}
