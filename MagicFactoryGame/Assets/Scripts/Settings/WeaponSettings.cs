using UnityEngine;

[CreateAssetMenu(fileName = "NewWaeponSettings", menuName = "Scriptable Object/WaeponSettings")]
public class WaeponSettings : LifeSettings
{
    [Space]
    [SerializeField] private float _cooldown;
    [SerializeField] private float _damage;

    public float Cooldown => _cooldown;
    public float Damage => _damage;
}
