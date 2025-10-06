using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolBase : MonoBehaviour
{   
    [Header("Object Pool Settings")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolSize;

    private Queue<GameObject> _pool;
    
    public int PoolSize => _poolSize;

    protected virtual void Awake()
    {
        _pool = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_prefab, transform);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    protected GameObject GetFromPool()
    {
        if (_pool.Count > 0)
        {
            var obj = _pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        
        return Instantiate(_prefab);
    }

    protected void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }
}
