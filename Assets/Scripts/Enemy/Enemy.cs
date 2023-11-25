using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Damageable Damageable { get; private set; }

    public float movementSpeed;
    public float attackCooldown;
    public int moneyGain;

	[HideInInspector]
	private float _remainingSlowdownTime;
    [HideInInspector]
    private float _remainingAttackCooldown;
    [HideInInspector]
    float _currentSpeed;

    Collider collider;

    private void Awake()
    {
        Damageable = GetComponent<Damageable>();
        _currentSpeed = movementSpeed;

        collider = GetComponent<Collider>();
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

        Damageable closestDamageable = TowersManager.Instance.GetClosestFriendly(transform.position);
        if (closestDamageable == null)
            return;
        
        if(Vector3.Distance(transform.position, closestDamageable.transform.position) <= Damageable.Radius) {
            if(_remainingAttackCooldown <= 0) {
                _remainingAttackCooldown += attackCooldown;
                Attack(closestDamageable);
            }
        } else {
            MoveTowards(closestDamageable.transform.position);
        }
    }

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 newDirection = (targetPosition - transform.position).normalized;
        newDirection.SetY(0);
        transform.position += newDirection * _currentSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(newDirection.x, newDirection.z) * Mathf.Rad2Deg, 0f);
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
