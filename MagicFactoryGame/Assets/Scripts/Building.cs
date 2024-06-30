using System;
using UnityEngine;

public class Building : LifeObject, IPoolObject
{
    public Type ItemType => GetType();
    public GameObject GameObject => gameObject;

    public void Repair(uint points)
    {
        AddHealth(points);
    }
}
