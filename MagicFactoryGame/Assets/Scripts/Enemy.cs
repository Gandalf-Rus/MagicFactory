using UnityEngine;

[RequireComponent(typeof(NavigationMovement))]
public class Enemy : LifeObject
{
    [SerializeField] EnemySettings _settings;

    private Building _target = null;
    private NavigationMovement _movement;

    private void Start()
    {
        _movement = GetComponent<NavigationMovement>();
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
