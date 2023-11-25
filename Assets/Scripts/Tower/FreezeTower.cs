using UnityEngine;

public class FreezeTower : ShootingTower
{
	public float reductionPercentage;
	public float slowTime;

    protected override void ShootAt(Enemy enemy)
    {
		Debug.Log("Shooting");
		Collider[] colliders = Physics.OverlapSphere(transform.position, Range);
		foreach (Collider col in colliders)
		{
			if(col.TryGetComponent<Enemy>(out enemy))
				enemy.ReduceSpeed(reductionPercentage, slowTime);
		}
    }
}