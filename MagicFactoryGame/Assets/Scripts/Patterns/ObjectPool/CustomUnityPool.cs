using UnityEngine;
using UnityEngine.Pool;

public class CustomUnityPool
{
    private ObjectPool<IPoolObject> _pool;
    private IPoolObject _poolItem;

    public CustomUnityPool(IPoolObject prefab)
    {
        _poolItem = prefab;
        _pool = new ObjectPool<IPoolObject>(createFunc: OnCreate, 
                                         actionOnGet: OnGet,
                                         actionOnRelease: OnRelease,
                                         actionOnDestroy: OnDestroy,
                                         collectionCheck: false);
    }

    private IPoolObject OnCreate()
    {
        IPoolObject obj = Object.Instantiate(_poolItem.GameObject).GetComponent<IPoolObject>();
        obj.GameObject.SetActive(false);
        return obj;
    }

    private void OnGet(IPoolObject obj)
    {
        if (obj == null)
            Debug.LogWarning($"{obj} isn't exist");
        obj.GameObject.SetActive(true);
    }

    private void OnRelease(IPoolObject obj)
    {
        obj.SetDefaultSettings();
        obj.GameObject.SetActive(false);
        if (obj == null)
            Debug.LogWarning($"{obj} isn't exist (release)");
    }

    private void OnDestroy(IPoolObject obj)
    {
        Object.Destroy(obj.GameObject);
        obj = null;
    }

    public IPoolObject Get()
    {
        IPoolObject obj = _pool.Get();
        return obj;
    }

    public void Return(IPoolObject obj)
    {
        _pool.Release(obj);
    }
}
