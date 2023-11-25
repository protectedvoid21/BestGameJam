using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    public GameObject enemyPrefab;

    private void Start()
    {
        if (!Application.isEditor)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject e = Instantiate(enemyPrefab, transform);
            e.transform.position = GameInput.GetWorldPointerPosition();
        }
    }
}
