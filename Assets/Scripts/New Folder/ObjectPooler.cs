using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

    }
    public float range = 20;
    #region Singleton
    private static ObjectPooler Instance;
    public static ObjectPooler Get()
    {
        return Instance;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                
                if(obj.CompareTag("Kegel"))
                {
                    obj.SetActive(true);
                    obj.transform.position = new Vector3(Random.Range(-range, range), 0.5f, Random.Range(-range, range)); 
                }
                else if(obj.CompareTag("KegelExplotion"))
                    obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't excist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IObjectPooler pooledObj = objectToSpawn.GetComponent<IObjectPooler>();
        if(pooledObj != null && objectToSpawn.CompareTag("KegelExplotion"))
        {
            pooledObj.OnObjectSpawn();
        }
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
