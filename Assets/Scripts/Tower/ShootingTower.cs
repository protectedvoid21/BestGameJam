using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingTower : Tower 
{
	public float Damage;
	public float FireCooldown;

	private EnemySelector enemySelector;

	new void Awake() {
		base.Awake();
		enemySelector = GetComponent<EnemySelector>();
	}

    protected override void Start()
    {
        base.Start();
    }

    void Update() {
		_currentFireCooldown = _currentFireCooldown - Time.deltaTime;
		if(_currentFireCooldown > 0)
			return;

		Enemy closestEnemy = enemySelector.Enemy;
		if(closestEnemy != null) {
			ShootAt(closestEnemy);
			_currentFireCooldown = FireCooldown;
		}
	}
 
	

	abstract protected void ShootAt(Enemy enemy);


	private float _currentFireCooldown = 0;
}

