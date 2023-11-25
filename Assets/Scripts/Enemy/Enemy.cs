using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Damageable Damageable { get; private set; }

    public float movementSpeed;
    public float attackCooldown;
    public float distanceToEnemyToAttack;
    public int moneyGain;

	[HideInInspector]
	private float _remainingSlowdownTime;
    [HideInInspector]
    private float _remainingAttackCooldown;
    [HideInInspector]
    float _currentSpeed;

    private void Awake()
    {
        Damageable = GetComponent<Damageable>();
        _currentSpeed = movementSpeed;
    }

    private void Start()
    {
        Damageable.OnDeath += GetDestroyed;
    }

    void Update()
    {
        _remainingSlowdownTime -= Time.deltaTime;
        if(_remainingSlowdownTime <= 0)
            _currentSpeed = movementSpeed;
        _remainingAttackCooldown -= Time.deltaTime;

        Tower closest_tower = TowersManager.Instance.GetClosestTower(transform.position);
        if(closest_tower == null)
            return;
        
        if(Vector3.Distance(transform.position, closest_tower.transform.position) <= distanceToEnemyToAttack) {
            if(_remainingAttackCooldown <= 0) {
                _remainingAttackCooldown = attackCooldown;
                Attack(closest_tower.damageable);
            }
        } else {
            MoveTowards(closest_tower.transform.position);
        }
    }

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 newDirection = (targetPosition - transform.position).normalized;
        newDirection.SetY(0);
        transform.position += newDirection * _currentSpeed * Time.deltaTime;
    }

    public abstract void Attack(Damageable currentTarget);

    public void ReduceSpeed(float percentage, float time) {
        _currentSpeed = Mathf.Min(movementSpeed * percentage, _currentSpeed);
        Debug.Log(movementSpeed * percentage);
        _remainingSlowdownTime = Mathf.Max(_remainingSlowdownTime, time);
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }

    void OnDestroy() {
        FindAnyObjectByType<PlayerMoney>()?.AddMoney(moneyGain);
    }
}
