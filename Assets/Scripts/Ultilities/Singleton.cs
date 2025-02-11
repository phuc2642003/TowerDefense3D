using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // private static instance
    static T instance;

    // public static instance used to refer to Singleton (e.g. MyClass.Instance)
    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    public virtual void Awake()
    {
        MakeSingleton(true);
    }

    public void MakeSingleton(bool destroyOnload)
    {
        if (instance == null)
        {
            instance = this as T;
            if (destroyOnload)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
