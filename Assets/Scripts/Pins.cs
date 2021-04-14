using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    [SerializeField]
    private GameObject pinObject;
    private Transform pinTransform;
    static int Score = 0;
    int points = 10;
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        pinTransform = pinObject.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Puntos: " + Score);
        if ( pinTransform.up.y <= 0.2  && isAlive)
        {
            isAlive = false;
            pinObject.SetActive(isAlive);
            Score += points;
        }
    }
}
