using UnityEngine;

public class Turret : Building
{
    [SerializeField] private float _rotationSpeed = 5f;
    
    private Enemy _target;
    Vector3 _direction;
    Quaternion _lookRotation;

    private void Update()
    {
        if (_target)
        {
            _direction = (_target.transform.position - transform.position).normalized;
            _lookRotation = Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, _lookRotation, Time.deltaTime * _rotationSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_target)
            return;
        other.TryGetComponent<Enemy>(out _target);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy exitingEnemy))
        {
            if (exitingEnemy == _target)
                _target = null;
        }
    }
}
