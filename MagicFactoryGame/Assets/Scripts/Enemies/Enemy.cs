using System;
using UnityEngine;

[RequireComponent(typeof(NavigationMovement))]
[RequireComponent (typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : LifeObject, IPoolObject
{
    [SerializeField] private EnemySettings _settings;
    
    [SerializeField] private Transform _baseTarget;

    protected Building _target = null;
    private NavigationMovement _movement;

    public Type ItemType => GetType();
    public GameObject GameObject => gameObject;

    private void Awake()
    {
        _movement = GetComponent<NavigationMovement>();
        InitialAction();
    }

    protected virtual void InitialAction()
    {
        _movement.SetTarget(_baseTarget);
    }

    protected void SetTarget(Building target)
    {
        _target = target;
        _movement.SetTarget(_target.transform);
    }

    protected void StopMovement()
    {
        _movement.Stop();
    }

    protected void ResumeMovement()
    {
        _movement.Resume();
    }
}
