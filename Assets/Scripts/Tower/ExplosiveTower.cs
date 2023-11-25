using UnityEngine;

public class ExplosiveTower : ShootingTower {
	public float bulletSpeed;
	public float explosionRadius;

	public ExplosiveBullet bulletPrefab;
	public Transform shootingPoint;

    protected override void ShootAt(Enemy enemy)
    {
		ExplosiveBullet bullet = Instantiate(bulletPrefab);
		bullet.damage = Damage;
		bullet.transform.position = shootingPoint.position;
		Vector3 dir = shootingPoint.forward;
		bullet.transform.rotation = shootingPoint.rotation;
		bullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed;
    }
}