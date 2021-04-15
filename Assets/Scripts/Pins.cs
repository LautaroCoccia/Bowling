using UnityEngine;

public class Pins : MonoBehaviour
{
    [SerializeField] private GameObject pinObject;
    private Transform pinTransform;
    int points = 10;
    bool isAlive = true;
    float maxRotation = 0.42f;
    // Start is called before the first frame update
    void Start()
    {
        pinTransform = pinObject.GetComponent<Transform>();
        LevelManager.Get().AddPins(1);
    }
    // Update is called once per frame
    void Update()
    {
        if ((pinTransform.rotation.x > maxRotation || pinTransform.rotation.x < -maxRotation ||
            pinTransform.rotation.z > maxRotation || pinTransform.rotation.z < -maxRotation || pinTransform.position.y < -1) && isAlive)
        {
            LevelManager.Get().AddScore(points);
            isAlive = false;
            pinObject.SetActive(isAlive);
            LevelManager.Get().AddPins(-1);
        }
    }
}
