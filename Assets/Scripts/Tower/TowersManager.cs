using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TowersManager : MonoBehaviour
{
    public static TowersManager Instance;

    public MainBase mainBase;

    public List<Tower> towers = new List<Tower>();

    private void Awake()
    {
        Instance = this;
    }

    public Damageable GetClosestFriendly(Vector3 position)
    {
        Damageable closestDamageable = null;
        float closestDistance = float.PositiveInfinity;
        float distance;

        foreach (Tower tower in towers)
        {
            if (tower == null) // Destroyed, but hasnt been removed yet
                continue;
            distance = Vector3.Distance(tower.transform.position, position);
            if (!tower.damageable.IsDead && distance < closestDistance)
            {
                closestDistance = distance;
                closestDamageable = tower.damageable;
            }
        }

        Tower closestTower = GetClosestTower(position);
        if (closestTower != null)
        {
            closestDistance = Vector3.Distance(closestTower.transform.position, position);
        }

        if (mainBase != null)
        {
            distance = Vector3.Distance(mainBase.transform.position, position);
            if (distance < closestDistance)
            {
                closestDamageable = mainBase.damageable;
                closestDistance = distance;
            }
        }

        if (Player.Instance != null)
        {
            distance = Vector3.Distance(Player.Instance.transform.position, position);
            if (distance < closestDistance)
            {
                closestDamageable = Player.Instance.damageable;
            }
        }

        return closestDamageable;
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
