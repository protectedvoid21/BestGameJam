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

    [HideInInspector]
    float _currentSpeed;
    [HideInInspector]
    float _remainingSlowdownTime;

    public float distanceToEnemyToAttack;

    private void Awake()
    {
        Damageable = GetComponent<Damageable>();
        _currentSpeed = _movementSpeed;
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
        _remainingSlowdownTime -= Time.deltaTime;
        // Debug.Log(_remainingSlowdownTime + " " + _currentSpeed);
        if(_remainingSlowdownTime <= 0)
            _currentSpeed = _movementSpeed;
    }

    void UpdateBrain()
    {
        _currentBehavior.Update();
    }

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 newDirection = (targetPosition - transform.position).normalized;
        newDirection.SetY(0);
        transform.position += newDirection * _currentSpeed * Time.deltaTime;
    }

    public abstract void StartAttacking(Damageable currentTarget);

    public void ReduceSpeed(float percentage, float time) {
        _currentSpeed = Mathf.Min(_movementSpeed * percentage, _currentSpeed);
        Debug.Log(_movementSpeed * percentage);
        _remainingSlowdownTime = Mathf.Max(_remainingSlowdownTime, time);
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }
}
