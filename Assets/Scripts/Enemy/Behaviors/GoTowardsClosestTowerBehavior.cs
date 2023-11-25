using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowardsClosestTowerBehavior : EnemyBehaviour
{
    Damageable _currentTarget;

    public GoTowardsClosestTowerBehavior(Enemy enemy) : base(enemy)
    {
        FindNewClosestTower();
    }

    public GoTowardsClosestTowerBehavior(Enemy enemy, Damageable currentTarget) : base(enemy)
    {
        SetNewTarget(currentTarget);
    }

    Damageable ScanForClosestTower()
    {
        //Transform.FindObjectsByType<Tower>(FindObjectsSortMode.None)
        Tower towerFound = TowersManager.Instance.GetClosestTower(self.transform.position);

        if (towerFound == null)
        {
            return null;
        }

        return towerFound.damageable;
    }

    void FindNewClosestTower()
    {
        SetNewTarget(ScanForClosestTower());
    }

    void SetNewTarget(Damageable newTarget)
    {
        if (newTarget == null)
        {
            return;
        }

        _currentTarget = newTarget;

        _currentTarget.OnDeath += FindNewClosestTower;
    }

    public override void Update()
    {
        if (_currentTarget == null)
        {
            // TODO: check if null and then scan
            return;
        }
        self.MoveTowards(_currentTarget.transform.position);

        float distanceToEnemy = Vector2.Distance(self.transform.position, _currentTarget.transform.position);

        if (distanceToEnemy <= self.distanceToEnemyToAttack)
        {
            self.StartAttacking(_currentTarget);
        }
    }
}
 