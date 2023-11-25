using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TowersManager : MonoBehaviour
{
    public static TowersManager Instance;

    public List<Tower> towers;

    private void Awake()
    {
        Instance = this;
    }

    // may return null
    public Tower GetClosestTower(Vector2 position)
    {
        Tower closestTower = null;
        float closestDistance = float.PositiveInfinity;

        foreach (Tower tower in towers)
        {
            if(tower == null) // Destroyed, but hasnt been removed yet
                continue;
            float distance = Vector2.Distance(tower.transform.position, position);
            if (!tower.damageable.IsDead && distance < closestDistance)
            {
                closestDistance = distance;
                closestTower = tower;
            }
        }


        return closestTower;
    }
}
