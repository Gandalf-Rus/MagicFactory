using System;

public interface IMoveable
{
    event Action<MovementState, bool> OnMovementStateChanged;
}
