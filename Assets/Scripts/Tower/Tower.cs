using Unity.VisualScripting;
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

    protected virtual void Awake() {
        damageable = GetComponent<Damageable>();
        damageable.OnDeath += GetDestroyed;
    }

    protected virtual void Start()
    {
        TowersManager.Instance.towers.Add(this);
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }

    public virtual void OnDestroy() {
        TowersManager.Instance.towers.Remove(this);
    }
}
 