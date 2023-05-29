using System.Collections.Generic;
using UnityEngine;

public class BasicObjectPooling : Singleton<BasicObjectPooling>
{
    [SerializeField] private ObjectPool Pool;
    [SerializeField] private List<ObjectPooled> ObjectPooledList;

    public void Queue(GameObject i_Object, eObjectPoolType i_Type)
    {
        for (int i = 0; i < ObjectPooledList.Count; i++)
        {
            if (ObjectPooledList[i].PoolType == i_Type)
            {
                for (int j = 0; j < ObjectPooledList[i].PoolObjects.Count; j++)
                {
                    if (ObjectPooledList[i].PoolObjects[j] == i_Object)
                        ObjectPooledList[i].PoolObjects[j].SetActive(false);
                }
            }
        }
    }

    public GameObject Dequeue(eObjectPoolType i_PoolType)
    {
        for (int i = 0; i < ObjectPooledList.Count; i++)
        {
            if(ObjectPooledList[i].PoolType == i_PoolType)
            {
                for (int j = 0; j < ObjectPooledList[i].PoolObjects.Count; j++)
                {
                    if (ObjectPooledList[i].PoolObjects[j].activeInHierarchy == false)
                    {
                        ObjectPooledList[i].PoolObjects[j].SetActive(true);
                        return ObjectPooledList[i].PoolObjects[j];
                    }
                }
            }
        }

        return null;
    }
}

[System.Serializable]
public class ObjectPool
{
    public eObjectPoolType PoolType;
    public int PoolObjectCount;
    public string PoolObjectName;
    public GameObject ObjectPrefab;
}

[System.Serializable]
public class ObjectPooled
{
    public eObjectPoolType PoolType;
    public Transform PoolParent;
    public List<GameObject> PoolObjects;

    public ObjectPooled(eObjectPoolType i_PoolType, Transform i_Parent, List<GameObject> i_PoolObjects)
    {
        PoolType = i_PoolType;
        PoolParent = i_Parent;
        PoolObjects = i_PoolObjects;
    }
}

[System.Serializable]
public enum eObjectPoolType
{
    Baging,
    Niyog,
    Tanso,
    Ugat,
    Langis,
    Rock,
    Page,
    Damage,
    Regine,
    Cornick,
    Bawang,
    Explosion
}
