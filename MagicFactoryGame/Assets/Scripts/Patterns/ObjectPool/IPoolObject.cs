using System;
using UnityEngine;

public interface IPoolObject
{
    Type ItemType { get; }
    GameObject GameObject { get; }

    static event Action<IPoolObject> OnUnuse;

    void SetDefaultSettings() { }

    void SetToUnuse()
    {
        OnUnuse?.Invoke(this);
    }
}
