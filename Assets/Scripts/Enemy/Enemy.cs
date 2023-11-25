using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Damageable Damageable { get; private set; }
    EnemyBehaviour _currentBehavior;

    [SerializeField]
    float _movementSpeed;

    public float distanceToEnemyToAttack;

    private void Awake()
    {
        Damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        Damageable.OnDeath += GetDestroyed;

        SetDefaultBehavior();
    }

    public void SetDefaultBehavior()
    {
        SetNewBehavior(new GoTowardsClosestTowerBehavior(this));
    }

    public void SetNewBehavior(EnemyBehaviour enemyBehaviour)
    {
        _currentBehavior = enemyBehaviour;
    }

    void Update()
    {
        UpdateBrain();
    }

    void UpdateBrain()
    {
        _currentBehavior.Update();
    }

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 newDirection = (targetPosition - transform.position).normalized;
        newDirection.SetY(0);
        transform.position += newDirection * _movementSpeed * Time.deltaTime;
    }

    public abstract void StartAttacking(Damageable currentTarget);

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }
}
