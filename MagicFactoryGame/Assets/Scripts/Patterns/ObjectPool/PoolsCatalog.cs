using System;
using System.Collections.Generic;

public class PoolsCatalog
{
    private readonly Dictionary<Type, CustomUnityPool> _pools = new Dictionary<Type, CustomUnityPool>();
  
    public CustomUnityPool GetPool(IPoolObject obj)
    {
        Type typeOfObject = obj.ItemType;
        if (!_pools.ContainsKey(typeOfObject))
            _pools.Add(typeOfObject, new CustomUnityPool(obj));

        return _pools[typeOfObject];
    }
}   