using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    private IControllable _controllable;
    private InputControls _inputControls;
    private Vector2 _moveDirectionInput;

    private void Awake()
    {
        _inputControls = new InputControls();

        _inputControls.Player.Move.performed += OnMove;
        _inputControls.Player.Move.canceled += OnStopMove;

        _inputControls.Player.Jump.performed += context => _controllable.Jump();
        _inputControls.Player.Run.performed += context => _controllable.Run();

        _controllable = GetComponent<IControllable>();
        if (_controllable == null)
            throw new Exception($"There is no IControllable on the object {gameObject.name}");

    }

    private void OnEnable()
    {
        _inputControls.Enable();      
    }

    private void OnDisable()
    {
        _inputControls.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveDirectionInput = context.ReadValue<Vector2>();
        _controllable.Move(new Vector3(_moveDirectionInput.x, 0f, _moveDirectionInput.y), true);
    }

    private void OnStopMove(InputAction.CallbackContext context)
    {
        _controllable.Move(Vector3.zero, false);
    }
}
