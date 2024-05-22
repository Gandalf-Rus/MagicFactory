using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour, IControllable, IMoveable
{
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private float _defaultSpeed = 2.5f;
    [SerializeField, Range(0, 2)] private float _runBoost = 0.5f;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _checkGroundRadius = 0.2f;
    [SerializeField] private LayerMask _groundMask;

    private float _speed;
    private Vector3 _moveDirection;
    private bool _isMoving;
    private bool _isRunActive = false;
    private float _verticalVelocity;
    private bool _isGrounded;

    public event Action<MovementState, bool> OnMovementStateChanged;

    private void OnValidate()
    {
        _characterController ??= GetComponent<CharacterController>();
        _speed = _defaultSpeed;
    }

    private void FixedUpdate()
    {
        _isGrounded = IsOnTheGround();

        if (_isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = _gravity;
        }

        else
            ApplyGravity();
        DoMove();
    }

    private bool IsOnTheGround()
    {
        return Physics.CheckSphere(_groundChecker.position, _checkGroundRadius, _groundMask); ;
    }

    private void ApplyGravity()
    {
        _verticalVelocity += _gravity * Time.fixedDeltaTime; // умножаем чтоб посчитать ускорение (v0+a*t)

        _characterController.Move(Vector3.up * _verticalVelocity * Time.fixedDeltaTime); // умножаем чтоб посчитать скорость (v*t)
    }

    private void DoMove()
    {
        _characterController.Move(_moveDirection * _speed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (!_isGrounded)
            return;
        _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
    }

    public void Move(Vector3 direction, bool isMoving)
    {
        _moveDirection = direction;
        if (_isMoving != isMoving)
        {
            Debug.Log("State Changed");
            _isMoving = isMoving;
            OnMovementStateChanged?.Invoke(MovementState.Walk, isMoving);
        }
    }

    public void Run()
    {
        if (_isRunActive)
        {
            _speed = _defaultSpeed;
            _isRunActive = false;
        }
        else
        {
            _speed += _defaultSpeed * _runBoost;
            _isRunActive = true;
        }

        OnMovementStateChanged?.Invoke(MovementState.Run, _isRunActive);
    }
}
