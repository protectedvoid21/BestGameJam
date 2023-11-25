using UnityEngine;

public class ExplosiveBullet : MonoBehaviour {
	public float maxDuration;

	[HideInInspector]
	public float speed;
	[HideInInspector]
	public float damage;
	[HideInInspector]
	public float radius;

	void Update() {
		maxDuration -= Time.deltaTime;
		if (maxDuration <= 0)
			Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider collider) {
		Enemy enemy = collider.GetComponent<Enemy>();
		if(enemy == null) 
			return;
		
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		foreach (Collider col in colliders)
		{
			if(col.TryGetComponent<Enemy>(out enemy))
				enemy.Damageable.GetDamaged(damage);
		}
		Destroy(gameObject);

	}
}