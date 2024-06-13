using UnityEngine;

abstract public class LifeObject : MonoBehaviour
{
    private uint _maxHealth;
    private uint _health;

    public void Init(uint health)
    {
        _maxHealth = health;
        _health = health;
    }

    public void TakeDamage(uint damage)
    {
        if (_health < damage)
            _health = 0;
        _health -= damage;
    }

    protected void AddHealth(uint healthPoints)
    {
        if (_health > _maxHealth)
            return;
        if (_health == _maxHealth)
        {
            _health = healthPoints;
            return;
        }
            _health += healthPoints;
    }
}
