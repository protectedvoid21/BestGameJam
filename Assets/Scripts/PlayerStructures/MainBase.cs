using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBase : MonoBehaviour
{
    [HideInInspector]
    public Damageable damageable;

    public virtual void Awake()
    {
        damageable = GetComponent<Damageable>();
        damageable.OnDeath += GetDestroyed;
    }

    public void GetDestroyed()
    {
        Debug.Log("YOU LOST THE GAME");
        Destroy(gameObject);
    }

    public virtual void OnDestroy()
    {
        //FindAnyObjectByType<TowersManager>()?.towers.Remove(this);
    }
}
