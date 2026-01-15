using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooling : MonoBehaviour
{
    public static ProjectilePooling Instance{ get; private set; }

    private Dictionary<string, Queue<GameObject>> pools;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log($"Already exists. Destroying this {gameObject.name}");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        pools = new Dictionary<string, Queue<GameObject>>();
    }

    /// <summary>
    /// Initialize pool with a prefab and a initial size.
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="initialSize"></param>
    public void InitPool(GameObject prefab, string id, int initialSize = 10)
    {
        if (!pools.ContainsKey(id))
        {
            pools[id] = new Queue<GameObject>();
        }

        for (int i = 0; i < initialSize; i++)
        {
            GameObject projectile = Instantiate(prefab, transform);
            projectile.SetActive(false);
            pools[id].Enqueue(projectile);
        }
    }

    /// <summary>
    /// Get an instance of the prefab with a set specified parent.
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject GetProjectile(GameObject prefab, string id, Transform parent = null)
    {
        if (!pools.ContainsKey(id) || pools[id].Count == 0)
        {
            ExpandPool(prefab, id, 10);
        }

        GameObject projectile = pools[id].Dequeue();
        projectile.SetActive(true);
        projectile.transform.SetParent(parent);
        return projectile;
    }

    /// <summary>
    /// Return a prefab instance back to the pool.
    /// </summary>
    /// <param name="projectile"></param>
    public void ReturnProjectile(string id, GameObject projectile)
    {
        if (pools.ContainsKey(id))
        {
            projectile.SetActive(false);
            projectile.transform.parent = transform;
            pools[id].Enqueue(projectile);
        }
        else
        {
            Debug.Log($"This object does not have a pool");
        }
    }

    /// <summary>
    /// Expand pool by a count.
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="count"></param>
    public void ExpandPool(GameObject prefab, string id, int count)
    {
        Debug.Log("Expanding pool by " + count);
        InitPool(prefab, id, count);
    }
}