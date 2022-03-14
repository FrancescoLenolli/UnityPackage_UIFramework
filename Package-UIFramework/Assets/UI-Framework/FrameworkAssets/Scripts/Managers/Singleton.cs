using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    [Tooltip("Check if the object has DontDestroyOnLoad property")]
    [SerializeField] bool dontDestroyable = true;
    public static T Instance
    {
        get
        {
            /*
             * Failsafe in case something needs a reference to instance
             * before it's initialised in the Awake method below.
             */
            if (!instance)
                instance = FindObjectOfType<T>();
            if (!instance)
                Debug.LogWarning($"No class of type {typeof(T)} found in the current Scene." +
                    $"This will lead to errors and to the app not running correctly.\n");

            return instance;
        }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (dontDestroyable) DontDestroyOnLoad(gameObject.transform.root);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this) instance = null;
    }
}
