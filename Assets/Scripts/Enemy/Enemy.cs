using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Damageable damageable;
    EnemyBehaviour currentBehavior;

    void Update()
    {
        
    }

    void UpdateBrain()
    {
        currentBehavior.Update();
    }

    public void MoveTowards(Vector2 targetPosition)
    {

    }
}
