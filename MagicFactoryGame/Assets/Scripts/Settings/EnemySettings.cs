using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemySettings", menuName = "Scriptable Object/EnemySettings")]
public class EnemySettings : LifeSettings
{
    [Space]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _detectionRadius;

    public float WalkSpeed => _walkSpeed;
    public float DetectionRadius => _detectionRadius;
}
