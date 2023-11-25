using System.Collections.Generic;
using UnityEngine;

class EnemySelector : MonoBehaviour
{
    public int Range;

    public Enemy Enemy { get; private set; }

    private void Start() { }

    void Update()
    {
        Enemy = GetClosestEnemy();
    }

    private Enemy GetClosestEnemy()
    {
        Collider[] allObjects = Physics.OverlapSphere(transform.position, Range);
        var enemies = new List<Enemy>();
        foreach (Collider col in allObjects)
        {
            if (col.gameObject.TryGetComponent<Enemy>(out var enemy))
                enemies.Add(enemy);
        }

        Enemy closestEnemy = null;
        float minSqrDist = float.MaxValue;
        foreach (Enemy e in enemies)
        {
            float sqrDist = Vector3.SqrMagnitude(e.transform.position - transform.position);
            if (sqrDist < minSqrDist)
            {
                closestEnemy = e;
                minSqrDist = sqrDist;
            }
        }

        return closestEnemy;
    }
}