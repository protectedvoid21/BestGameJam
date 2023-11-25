using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public float Health { get => _health; private set => _health = value; }
    public float MaxHealth { get => _maxHealth; private set => _maxHealth = value; }
    [SerializeField]
    float _health;
    float _maxHealth;

    bool _dead = false;
    public UnityAction OnDeath;

    [field: SerializeField]
    public bool IsEnemy { get; private set; }

    public bool IsDead { get => _dead; }

    [field: SerializeField]
    public float Radius { get; private set; }

    private void Start()
    {
        if (Radius < 0.01f)
        {
            Debug.Log("Did you set the Damageable radius? " + name);
        }

        _maxHealth = _health;
    }

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
 