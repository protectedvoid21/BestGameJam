using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingTower : Tower 
{
	public float Damage;
	public float FireCooldown;

	

	void Update() {
		_currentFireCooldown = Mathf.Min(0, _currentFireCooldown - Time.deltaTime);

		Enemy closestEnemy = GetClosestEnemy();
		if(closestEnemy != null) {
			ShootAt(closestEnemy);
			_currentFireCooldown = FireCooldown;
		}
	}

	Enemy GetClosestEnemy() {
		Collider[] allObjects = Physics.OverlapSphere(transform.position, Range);
		List<Enemy> enemies = new List<Enemy>();
		foreach(Collider col in allObjects) {
			if(col.gameObject.TryGetComponent<Enemy>(out var enemy))
				enemies.Add(enemy);
		}

		Enemy closestEnemy = null;
		float minSqrDist = float.MaxValue;
		foreach(Enemy e in enemies) {
			float sqrDist = Vector3.SqrMagnitude(e.transform.position - transform.position);
			if(sqrDist < minSqrDist) {
				closestEnemy = e;
				minSqrDist = sqrDist; 
			}
		}
		return closestEnemy;
	}

	abstract protected void ShootAt(Enemy enemy);


	private float _currentFireCooldown = 0;
}

