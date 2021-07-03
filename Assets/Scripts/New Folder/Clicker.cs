using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public Camera fpsCamera;
    Vector3 mousePos;
    Ray ray;
    public int maxSpawn = 6;
    bool canSpawn = true;
    private void Start()
    {
        fpsCamera = Camera.main;
    }
    void Update()
    {
        mousePos = Input.mousePosition;
        ray = fpsCamera.ScreenPointToRay(mousePos);

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale>0)
        {
            Spawn();
        }
    }
    void Spawn()
    {
        canSpawn = false;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag =="Kegel")
            {
                for (int i = 0; i <= maxSpawn; i++)
                {
                    ObjectPooler.Get().SpawnFromPool("KegelExplotion", hit.transform.position, Quaternion.identity);
                }
                hit.transform.gameObject.GetComponent<Kergel>().DisableKegel();
            }
            else if(hit.transform.tag == "Floor")
            {
                LevelManager.Get().UpdateLives();
            }
            
        }
        
    }
}
