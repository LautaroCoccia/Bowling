using UnityEngine;

public class Kergel : MonoBehaviour
{
    [SerializeField] private GameObject kegelObj;
    private Transform pinTransform;
    int points = 10;
    bool isAlive = true;
    float maxRotation = 0.42f;
    // Start is called before the first frame update
    void Start()
    {
        pinTransform = kegelObj.GetComponent<Transform>();
        LevelManager.Get().AddPins(1);
    }
    // Update is called once per frame
    void Update()
    {
        if (GetRotation() && isAlive)
        {
            DisableKegel();
        }
    }
    public void DisableKegel()
    {
        LevelManager.Get().AddScore(points);
        isAlive = false;
        kegelObj.SetActive(isAlive);
        LevelManager.Get().AddPins(-1);
    }
    bool GetRotation()
    {
        if (pinTransform.rotation.x > maxRotation || pinTransform.rotation.x < -maxRotation ||
            pinTransform.rotation.z > maxRotation || pinTransform.rotation.z < -maxRotation || pinTransform.position.y < -maxRotation)
        {
            return true;
        }
        else return false;
    }
}
