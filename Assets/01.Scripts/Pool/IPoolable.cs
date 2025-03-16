using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public string Name { get; }

    public GameObject PoolingObject { get; }

    public void Reset();
}
