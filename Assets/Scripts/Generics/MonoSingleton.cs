using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
             if (instance == null)
            {
                GameObject singletonObj = new GameObject(typeof(T).Name);
                instance = singletonObj.AddComponent<T>();
            }
            
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = (T)this;
        DontDestroyOnLoad(gameObject);
        Init();
    }

    public abstract void Init();
}
