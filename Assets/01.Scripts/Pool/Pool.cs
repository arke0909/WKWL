using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Stack<IPoolable> _pool;
    private Transform _parentsTrm;
    private IPoolable _poolObject;
    private GameObject _poolingPrefab;

    public Pool(IPoolable poolingObject, Transform parentsTrm, int count)
    {
        _pool = new Stack<IPoolable>(count);
        _parentsTrm = parentsTrm;
        _poolObject = poolingObject;
        _poolingPrefab = poolingObject.PoolingObject;

        for (int i = 0; i < count; i++)
        {
            GameObject poolObj = GameObject.Instantiate(_poolingPrefab,_parentsTrm);
            poolObj.SetActive(false);
            poolObj.name = _poolObject.Name;
            IPoolable pool = poolObj.GetComponent<IPoolable>();
            _pool.Push(pool);
        }
    }

    public IPoolable Pop()
    {
        IPoolable item = null;
        if (_pool.Count <= 0)
        {
            GameObject popObj = GameObject.Instantiate (_poolingPrefab,_parentsTrm);
            popObj.name = _poolObject.Name;
            item = popObj.GetComponent<IPoolable>();
        }
        else
        {
            item = _pool.Pop();
            item.PoolingObject.SetActive(true);
        }

        return item;
    }

    public void Push(IPoolable item)
    {
        item.PoolingObject.SetActive(false);
        _pool.Push(item);
    }
}
