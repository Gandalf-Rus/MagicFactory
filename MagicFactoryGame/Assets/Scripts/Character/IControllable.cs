using UnityEngine;

public interface IControllable
{
    void Move(Vector3 direction, bool isMove);
    void Jump();
    void Run();
}
