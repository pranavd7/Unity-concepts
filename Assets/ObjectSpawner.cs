using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private Queue<GameObject> spawnedGameObjects;
    private const string PREFAB_ID = "bullet";

    void Start()
    {
        spawnedGameObjects = new Queue<GameObject>();
        ProjectilePooling.Instance.InitPool(prefab, PREFAB_ID, 5);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject instance = ProjectilePooling.Instance.GetProjectile(prefab, PREFAB_ID, transform);
            instance.transform.position = Random.Range(-1, 1) * Vector3.one;
            spawnedGameObjects.Enqueue(instance);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject instance = spawnedGameObjects.Dequeue();
            ProjectilePooling.Instance.ReturnProjectile(PREFAB_ID, instance);
        }
    }
}
