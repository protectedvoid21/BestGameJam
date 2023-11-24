using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour
{
    protected Enemy _enemy;

    public EnemyBehaviour(Enemy enemy)
    {
        _enemy = enemy;
    }

    public abstract void Update();
}
