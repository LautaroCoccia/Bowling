using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float force = 0.0f;
    private Rigidbody BallRigiddbody;
    // Start is called before the first frame update
    void Start()
    {
        BallRigiddbody = GetComponent<Rigidbody>();
        BallRigiddbody.AddForce(Vector3.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        BallRigiddbody.velocity=(Vector3.forward *force/2);
    }
}
