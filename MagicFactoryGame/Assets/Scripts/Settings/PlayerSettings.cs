using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerSettings", menuName = "Scriptable Object/PlayerSettings")]
public class PlayerSettings : LifeSettings
{
    [Space]
    [SerializeField] private float _walkSpeed;
    [SerializeField, Range(1, 2)] private float _runModifier = 1.5f;
    [SerializeField] private float _jumpHeight = 3f;

    public float WalkSpeed => _walkSpeed;
    public float RunModifier => _runModifier;
    public float JumpHeight => _jumpHeight;
}
