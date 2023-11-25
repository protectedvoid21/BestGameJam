using UnityEngine;

public class BasicTower : ShootingTower
{
	public float bulletSpeed;
	public BasicBullet bulletPrefab;
	public Transform shootingPoint;

    private void Start()
    {
		GetComponent<BasicTower>().Range = Range;
	}

	protected override void ShootAt(Enemy enemy)
	{
		BasicBullet bullet = Instantiate(bulletPrefab);
		bullet.damage = Damage;

		bullet.transform.position = shootingPoint.position;
		Vector3 dir = shootingPoint.forward;
		bullet.transform.rotation = shootingPoint.rotation;
		bullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed;
	}
} 