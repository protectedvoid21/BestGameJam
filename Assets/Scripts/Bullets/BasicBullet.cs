using UnityEngine;

public class BasicBullet : MonoBehaviour {
	public float maxDuration;

	[HideInInspector]
	public float speed;
	[HideInInspector]
	public Vector3 direction;
	[HideInInspector]
	public float damage;

	void Update()
	{
		maxDuration -= Time.deltaTime;
		if (maxDuration <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void OnTriggerEnter(Collider collider)
	{
		Debug.Log("Trigger entered");
		Enemy enemy = collider.GetComponent<Enemy>();
		if (enemy != null)
		{
			Damageable enemyDmg = enemy.Damageable;
			enemyDmg.GetDamaged(damage);
			Destroy(gameObject);
		}
	}
};