using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour
{
    protected Enemy self;

    public EnemyBehaviour(Enemy self)
    {
        this.self = self;
    }

    public abstract void Update();
}
