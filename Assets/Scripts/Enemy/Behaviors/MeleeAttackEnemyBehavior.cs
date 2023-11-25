using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackEnemyBehavior : EnemyBehaviour
{
    MeleeEnemy _meleeEnemy;
    Damageable _currentTarget;

    float _attackCooldown;

    public MeleeAttackEnemyBehavior(MeleeEnemy enemy, Damageable currentTarget) : base(enemy)
    {
        _meleeEnemy = enemy;
        _currentTarget = currentTarget;

        _currentTarget.OnDeath += StopAttackingTarget;
    }

    public override void Update()
    {
        _attackCooldown -= Time.deltaTime;

        if (_attackCooldown > 0)
        {
            return;
        }

        _attackCooldown += _meleeEnemy.DefaultAttackCooldown;

        _currentTarget.GetDamaged(_meleeEnemy.Damage);
    }

    void StopAttackingTarget()
    {
        self.SetDefaultBehavior();
    }
}
