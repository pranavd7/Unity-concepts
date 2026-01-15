using System.Collections.Generic;
using  UnityEngine;

class DataStore<T>
{
    public T Data { get; set; }
}

class KeyValuePair<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
}


public class ObjectPools<T> where T : Component
{
    private List<DataStore<int>> list1 = new List<DataStore<int>>();
    private Queue<float> queue = new Queue<float>();
    private Queue<string> queueString = new Queue<string>();
    
    private Queue<T> pool = new Queue<T>();

    public T Get(T prefab)
    {
        if (pool.Count == 0)
            AddObjects(prefab, 1);

        return pool.Dequeue();
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }

    private void AddObjects(T prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newObj = GameObject.Instantiate(prefab);
            newObj.gameObject.SetActive(false);
            pool.Enqueue(newObj);
        }
    }
}