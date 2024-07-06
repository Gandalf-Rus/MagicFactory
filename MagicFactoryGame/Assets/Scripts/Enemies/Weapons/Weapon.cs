using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WaeponSettings _settings;

    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    protected IEnumerator AttackCoroutine()
    {
        yield return null;
    }
}
