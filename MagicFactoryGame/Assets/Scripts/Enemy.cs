using UnityEngine;

public class Enemy : LifeObject
{
    [SerializeField] EnemySettings _settings;

    private float _detectionRadius;
    private float _walkSpeed;
    private Building _target = null;
    private Vector3 _direction;

    private void Start()
    {
        _walkSpeed = _settings.WalkSpeed;
        _detectionRadius = _settings.DetectionRadius;
    }

    void FixedUpdate()
    {
        if (_target == null)
            FindBuilding();
        else
            MoveTowardsBuilding();
    }

    void FindBuilding()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _detectionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            _target = hitCollider.GetComponent<Building>();
            if (_target != null)
                break;
        }
    }

    void MoveTowardsBuilding()
    {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _walkSpeed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}