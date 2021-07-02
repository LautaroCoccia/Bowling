using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody BallRigidbody;
    float actuallPos = 0;
    float maxPosX = 7;
    Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        BallRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.Get().GetForceActive())
        {
            SetHorizontalPos();
        }
        else
            BallRigidbody.AddForce(LevelManager.Get().GetSpeed() );
        ResetPos();
    }
    void SetHorizontalPos()
    {
        actuallPos += Input.GetAxis("Horizontal");
        transform.position = (new Vector3(actuallPos, transform.position.y, 0));
        if (transform.position.x > maxPosX)
        {
            transform.position = new Vector3(maxPosX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -maxPosX)
        {
            transform.position = new Vector3(-maxPosX, transform.position.y, transform.position.z);
        }
    }
    void ResetPos()
    {
        if(transform.position.y<-1)
        {
            transform.position = initialPos;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            BallRigidbody.AddForce(Vector3.zero);
            BallRigidbody.rotation = Quaternion.Euler(Vector3.zero); 
            LevelManager.Get().SetForceActive();
            LevelManager.Get().UpdateLives();
        }
    }
}