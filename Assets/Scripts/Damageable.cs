using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public float Health { get => _health; private set => _health = value; }
    [SerializeField]
    float _health;

    bool _dead = false;
    public UnityAction OnDeath;

    [field: SerializeField]
    public bool IsEnemy { get; private set; }

    public bool IsDead { get => _dead; }

    public bool GetDamaged(float damage)
    {
        _health -= damage;

        if (_health <= 0 && !_dead)
        {
            Die();
        }

        return _health <= 0;
    }

    public void Die()
    {
        _dead = true;

        OnDeath?.Invoke();
    }
}
 