using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowardsClosestTowerBehavior : EnemyBehaviour
{
    Damageable _currentTarget;

    public GoTowardsClosestTowerBehavior(Enemy enemy, Damageable currentTarget) : base(enemy)
    {
        _currentTarget = currentTarget;
    }

    public override void Update()
    {

    }
}
