using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float Health { get => _health; private set => _health = value; }
    [SerializeField]
    float _health;

    public bool IsEnemy { get; private set; }
}
 