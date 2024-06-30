using System.Collections;
using UnityEngine;

public class TestEnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;

    private YieldInstruction _waitInstruction;
    private IPoolObject _poolObject;

    private void Start()
    {
        _waitInstruction = new WaitForSeconds(1);
        StartCoroutine(SpawnCoroutine());

    }

    private IEnumerator SpawnCoroutine()
    {
        int i = 0;
        while(true)
        {
            _poolObject = PoolObjectsAccessor.Instance.GetObject(_enemy);
            _poolObject.GameObject.transform.position = _spawnPoints[i % _spawnPoints.Length].position;
            i++;
            yield return _waitInstruction;
        }
    }
}
