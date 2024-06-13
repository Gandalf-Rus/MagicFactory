using UnityEngine;

abstract public class LifeSettings : ScriptableObject
{
    [SerializeField] private uint _health;

    public uint Health => _health;
}