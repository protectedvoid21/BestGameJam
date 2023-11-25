using UnityEngine;

class EnemySpawner : MonoBehaviour {
	public Enemy enemyPrefab;
	public float spawnInterval;
	public int groupSize;
	public float maxSpawnRadius, minSpawnRadius;
	public float groupSpread;


	private float _spawnCooldown;

	void Awake() {
		_spawnCooldown = spawnInterval;
	}

	void Update() {
		_spawnCooldown -= Time.deltaTime;
		if(_spawnCooldown <= 0) {
			SpawnGroup();
			_spawnCooldown = spawnInterval;
		}
	}

	void SpawnGroup() {
		float radius = Random.Range(minSpawnRadius, maxSpawnRadius);
		Vector2 center = Random.insideUnitCircle.normalized * radius;

		for (int i = 0; i < groupSize; i++)
		{
			Vector2 offset = Random.insideUnitCircle * groupSpread;
			Vector2 pos2D = center + offset;
			
			Enemy enemy = Instantiate(enemyPrefab, transform);
			enemy.transform.position = new Vector3(pos2D.x, 0, pos2D.y);
		}
	}
}