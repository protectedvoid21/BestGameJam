using UnityEngine;

class TowerRotate : MonoBehaviour
{
    public Transform head;

    private EnemySelector _selector;

    void Awake()
    {
        _selector = GetComponent<EnemySelector>();
    }

    void Update()
    {
        Enemy enemy = _selector.Enemy;
        if (enemy == null)
            return;

        Vector3 direction = enemy.transform.position - transform.position;
        Vector2 dir2D = new Vector2(direction.x, direction.z);
        if (dir2D.magnitude < 0.01f)
        {
            return;
        }

        Vector3 dir = new Vector3(direction.x, 0, direction.z);

        Quaternion rotation = Quaternion.LookRotation(dir) * Quaternion.Euler(-90, -90, 0);
        head.rotation = rotation;
    }
}