using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            _instance = FindObjectOfType<T>();

            if (_instance == null)
            {
                GameObject obj = new GameObject();
                _instance =  obj.AddComponent<T>();
                obj.name = "[Singleton] " + typeof(T).Name;
            }

            return _instance;
        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }
}
