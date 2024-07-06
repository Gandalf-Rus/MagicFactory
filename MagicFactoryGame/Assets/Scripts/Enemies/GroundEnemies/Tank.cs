using UnityEngine;

public class Tank : GroundEnemy
{
    [SerializeField] private Transform _turret;
    [SerializeField] private float _turretRotationSpeed = 2f;

    private void Update()
    {
        if (_target != null)
            RotateTurretTowardsTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_target is null && other.TryGetComponent(out _target))
        {
            StopMovement();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_target == other.GetComponent<Building>())
        {
            _target = null;
            ResumeMovement();
        }
    }

    private void RotateTurretTowardsTarget()
    {
        if (_turret == null)
            return;

        Vector3 targetDirection = _target.transform.position - _turret.position;
        targetDirection.y = 0; // »гнорируем вертикальную составл€ющую

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        _turret.rotation = Quaternion.Slerp(_turret.rotation, targetRotation, _turretRotationSpeed * Time.deltaTime);
    }
}