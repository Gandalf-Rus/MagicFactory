using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerSettings", menuName = "Scriptable Object/PlayerSettings")]
public class PlayerSettings : LifeSettings
{
    [Space]
    [SerializeField] private float _walkSpeed;
    [SerializeField, Range(0, 2)] private float _runModifier = 0.5f;
    [SerializeField] private float _jumpHeight = 3f;

    public float WalkSpeed => _walkSpeed;
    public float RunModifier => _runModifier;
    public float JumpHeight => _jumpHeight;
}
