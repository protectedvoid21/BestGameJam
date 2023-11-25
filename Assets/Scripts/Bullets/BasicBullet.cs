using UnityEngine;

public class BasicBullet : MonoBehaviour {
	[HideInInspector]
	public float speed;
	[HideInInspector]
	public Vector3 direction;
	public float maxDuration;
	public float damage;

	void Update()
	{
		maxDuration -= Time.deltaTime;
		if (maxDuration <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider collider)
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