using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : LifeObject, IControllable, IMoveable
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerSettings _playerSettings;

    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _checkGroundRadius = 0.2f;
    [SerializeField] private LayerMask _groundMask;

    private float _walkSpeed;
    private float _runModifier;
    private float _jumpHeight;

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
    }

    private void Start()
    {
        Init(_playerSettings.Health);
        _walkSpeed = _playerSettings.WalkSpeed;
        _runModifier = _playerSettings.RunModifier;
        _jumpHeight = _playerSettings.JumpHeight;
        _speed = _walkSpeed;
    }

    private void FixedUpdate()
    {
        UpdateGroundStatus();
        ApplyGravity();
        MoveCharacter();
    }

    private void UpdateGroundStatus()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _checkGroundRadius, _groundMask);
        if (_isGrounded && _verticalVelocity < 0)
            _verticalVelocity = _gravity;
    }

    private void ApplyGravity()
    {
        if (!_isGrounded)
            _verticalVelocity += _gravity * Time.fixedDeltaTime;

        _characterController.Move(Vector3.up * _verticalVelocity * Time.fixedDeltaTime);
    }

    private void MoveCharacter()
    {
        _characterController.Move(_moveDirection * _speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
            _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
    }

    public void Move(Vector3 direction, bool isMoving)
    {
        _moveDirection = direction;
        if (_isMoving != isMoving)
        {
            _isMoving = isMoving;
            OnMovementStateChanged?.Invoke(MovementState.Walk, isMoving);
        }
    }

    public void Run()
    {
        _isRunActive = !_isRunActive;
        Debug.Log(_isRunActive);
        _speed = _isRunActive ? _walkSpeed * _runModifier : _walkSpeed;
        OnMovementStateChanged?.Invoke(MovementState.Run, _isRunActive);
    }
}
