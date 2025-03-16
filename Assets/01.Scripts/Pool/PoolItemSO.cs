using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Pool/Item")]
public class PoolItemSO : ScriptableObject
{
    public string _name;
    public GameObject _poolObj;
    public int _count;

    private void OnValidate()
    {
        if (_poolObj != null)
        {
            IPoolable item = _poolObj.GetComponent<IPoolable>();
            if (item == null)
            {
                Debug.LogError($"IPoolale isn't in {_poolObj.name}");
                _poolObj = null;
            }
            else
            {
                _name = _poolObj.name;
            }
        }
    }

}
