using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [field: SerializeField]
    public float DefaultAttackCooldown { get; private set; }

    [field: SerializeField]
    public float Damage { get; private set; }

    public override void StartAttacking(Damageable currentTarget)
    {
        SetNewBehavior(new MeleeAttackEnemyBehavior(this, currentTarget));
    }
}
