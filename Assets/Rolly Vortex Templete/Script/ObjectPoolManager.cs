using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {
    // static variables
    public static ObjectPoolManager instance;

    // GUI editable variables

    // private references & variables
    Dictionary<string, ObjectPool> objectPools = new Dictionary<string, ObjectPool>();

    // public functions
    public void RegisterPool(string id, GameObject objectInPool)
    {
        if (!objectPools.ContainsKey(id))
        {
            var newPool = new ObjectPool();
            newPool.baseObject = objectInPool;
            newPool.baseObject.SetActive(false);
            objectPools.Add(id, newPool);
        }
        else
        {
            objectPools[id].baseObject = objectInPool;
            objectPools[id].baseObject.SetActive(false);
        }
    }

    public void ClearSpecificPool(string id)
    {
        if (objectPools.ContainsKey(id))
        {
            objectPools[id].pool.Clear();
        }
    }

    public void ResetPool()
    {
        var keys = new List<string>();
        foreach(var p in objectPools)
        {
            keys.Add(p.Key);
            var currentPool = p.Value.pool;
            foreach(var c in currentPool)
            {
                if (c != null)
                {
                    Destroy(c);
                }
            }
            currentPool.Clear();
        }
        foreach(var k in keys)
        {
            objectPools.Remove(k);
        }
    }

    public void ClearPoolObjects()
    {
        var keys = new List<string>();
        foreach (var p in objectPools)
        {
            keys.Add(p.Key);
            var currentPool = p.Value.pool;
            foreach (var c in currentPool)
            {
                if (c != null)
                {
                    Destroy(c);
                }
            }
            currentPool.Clear();
        }
    }

    public void ClearSpawnObjectInstances()
    {
        var keys = new List<string>();
        foreach(var p in objectPools)
        {
            if (p.Key.ToString().Contains("Enemy") || p.Key.ToString().Contains("Item"))
            {
                keys.Add(p.Key);
                var enemyPool = p.Value.pool;
                foreach(var e in enemyPool)
                {
                    if (e != null)
                    {
                        Destroy(e);
                    }
                }
                enemyPool.Clear();
            }
        }
        foreach(var k in keys)
        {
            objectPools.Remove(k);
        }
    }

    public GameObject GetInstance(string id)
    {
        if (objectPools.ContainsKey(id))
        {
            var aimPool = objectPools[id];
            var aimObject = aimPool.GetObject();
            aimObject.SetActive(true);
            return aimObject;
        }
        else
        {
            return null;
        }
    }

    public void BackToPool(GameObject aimObject, string id)
    {
        if (objectPools.ContainsKey(id))
        {
            objectPools[id].ReturnObject(aimObject);
        }
        else
        {
            Destroy(aimObject);
        }
    }

    // Use this for initialization
    public void Initialize()
    {
        instance = this;
    }

    private void Awake()
    {
        Initialize();
    }

    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class ObjectPool
{
    public GameObject baseObject = null;
    public Stack<GameObject> pool = new Stack<GameObject>();

    public GameObject GetObject()
    {
        if(baseObject == null)
        {
            return null;
        }
        else
        {
            GameObject aimObject = null;
            if(pool.Count > 0)
            {
                aimObject = pool.Pop();
            }
            else
            {
                aimObject = Object.Instantiate(baseObject);
            }
            return aimObject;
        }
    }

    public void ReturnObject(GameObject aimObject)
    {
        aimObject.SetActive(false);
        pool.Push(aimObject);
    }
}
