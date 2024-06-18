using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerScript : MonoBehaviour
{
    public static ObjectPoolerScript current;
    public GameObject pooledObject;
    public int currentAmount;
    public int pooledAmount = 20;
    public bool willGrow = true;

    private List<GameObject> pooledObjects;

    private void Awake()
    {
        current = this;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            var obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        currentAmount = pooledObjects.Count;

        for (int i = 0; i < pooledObjects.Count; i++)
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        if (willGrow)
        {
            var obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}