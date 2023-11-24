using UnityEngine;

public class BasicBullet : MonoBehaviour {
	[HideInInspector]
	public float speed;
	[HideInInspector]
	public Vector3 direction;
	public float maxDuration;

	void Update() {
		maxDuration -= Time.deltaTime;
		if(maxDuration <= 0)
			Destroy(gameObject);
	}
};