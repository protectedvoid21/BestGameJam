using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthBar : MonoBehaviour
{
    [SerializeField]
    Damageable damageable;
    public float DefaultXWidth;

    [SerializeField]
    GameObject healthBar;

    private void Update()
    {
        if (damageable.Health < damageable.MaxHealth)
        {
            healthBar.transform.localScale = new Vector3(damageable.Health / damageable.MaxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

            healthBar.transform.LookAt(Camera.main.transform);
        }
    }
}
