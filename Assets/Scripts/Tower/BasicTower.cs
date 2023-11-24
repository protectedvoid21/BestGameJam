using UnityEngine;

public class BasicTower : ShootingTower
{
	public float bulletSpeed;

	public BasicBullet bulletPrefab;
	public Transform shootingPoint;

    protected override void ShootAt(Enemy enemy)
    {
		BasicBullet bullet = Instantiate(bulletPrefab);
		bullet.transform.position = shootingPoint.position;
		Vector3 dir = enemy.transform.position - transform.position;
		bullet.transform.rotation = Quaternion.LookRotation(dir);
		bullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed;
    }
} 