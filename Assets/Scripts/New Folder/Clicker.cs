using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public Camera fpsCamera;
    public Kergel kergel;
    Vector3 mousePos;
    Ray ray;
    public int maxSpawn = 6;
    bool canSpawn = false;
    private void Start()
    {
        fpsCamera = Camera.main;
    }
    void Update()
    {
        mousePos = Input.mousePosition;
        ray = fpsCamera.ScreenPointToRay(mousePos);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Spawn();
            
        }
    }
    void Spawn()
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.position == kergel.transform.position && hit.transform.tag =="Kegel")
            {
                for (int i = 0; i <= maxSpawn; i++)
                {
                    ObjectPooler.Get().SpawnFromPool("KegelExplotion", transform.position, Quaternion.identity);
                }
                canSpawn = false;
                kergel.DisableKegel();
            }
            else
            {
                LevelManager.Get().UpdateLives();
            }
        }
        
    }
}
