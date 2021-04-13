using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float force = 0.0f;
    private Rigidbody BallRidbody;
    // Start is called before the first frame update
    void Start()
    {
        BallRidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BallRidbody.AddForce(Vector3.forward * force * Time.deltaTime);
    }
}
