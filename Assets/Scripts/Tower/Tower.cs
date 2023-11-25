using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [HideInInspector]
    public Damageable damageable;

    public int Range;
    public float BuildCost;
    public float UpgradeCost;
    public int Level = 1;
    public int MaxLevel;
    
    public virtual void Awake() {
        damageable = GetComponent<Damageable>();
        damageable.OnDeath += GetDestroyed;
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }

}
 