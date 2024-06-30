using UnityEngine;

public class PoolObjectsAccessor : MonoBehaviour
{
    private PoolsCatalog _poolCatalog;
    private static PoolObjectsAccessor _instance;
    public static PoolObjectsAccessor Instance => _instance;

    private void OnValidate()
    {
        if (_instance != null)
        {
            Debug.LogError("Component PoolsCatalog already exist in current scene");
            return;
        }
        _poolCatalog = new PoolsCatalog();
       
        _instance = this;
    }

    private void OnEnable()
    {
        IPoolObject.OnUnuse += ReleaseObject;
    }

    private void OnDisable()
    {
        IPoolObject.OnUnuse -= ReleaseObject;
    }

    public IPoolObject GetObject(IPoolObject obj)
    {
        IPoolObject poolItem = _poolCatalog.GetPool(obj).Get();
        return poolItem;
    }

    private void ReleaseObject(IPoolObject obj)
    {
        _poolCatalog.GetPool(obj).Return(obj);
    }
}
