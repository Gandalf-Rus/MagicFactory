using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationMovement : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _agent;
    private bool _isStopped = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (_target == null || _isStopped)
            return;
        _agent.destination = _target.position;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        _isStopped = false;
    }

    public void LoseTarget()
    {
        _target = null;
    }

    public void Stop()
    {
        _isStopped = true;
        _agent.isStopped = true;
    }

    public void Resume()
    {
        _isStopped = false;
        _agent.isStopped = false;
    }
}