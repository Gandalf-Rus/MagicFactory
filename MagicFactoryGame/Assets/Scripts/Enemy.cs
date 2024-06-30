using System;
using UnityEngine;

[RequireComponent(typeof(NavigationMovement))]
[RequireComponent (typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : LifeObject, IPoolObject
{
    [SerializeField] private EnemySettings _settings;
    [SerializeField] private Transform _baseTarget;

    private Building _target = null;
    private NavigationMovement _movement;

    public Type ItemType => GetType();
    public GameObject GameObject => gameObject;

    private void Awake()
    {
        _movement = GetComponent<NavigationMovement>();
        if (_target == null)
            _movement.SetTarget(_baseTarget);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_target != null)
            return;
        if (other.TryGetComponent(out _target))
        {
            Debug.Log(_target.name);
            _movement.SetTarget(_target.transform);
        }
    }
}
