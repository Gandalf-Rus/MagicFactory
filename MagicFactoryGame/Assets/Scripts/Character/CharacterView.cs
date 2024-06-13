using System;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private IMoveable _moveable;
    private bool _currentParam;

    private void OnValidate()
    {
        _moveable = GetComponent<IMoveable>();

        if (_moveable == null)
            throw new Exception($"There is no IMoveable on the object {gameObject.name}");
    }

    private void OnEnable()
    {
        _moveable.OnMovementStateChanged += SwichAnimatorParam;
    }

    private void OnDisable()
    {
        _moveable.OnMovementStateChanged -= SwichAnimatorParam;
    }

    private void SwichAnimatorParam(MovementState param, bool flag)
    {
        _currentParam = _animator.GetBool(param.ToString());
        if (_currentParam != flag)
        {
            _animator.SetBool(param.ToString(), flag);
        }
    }

}
