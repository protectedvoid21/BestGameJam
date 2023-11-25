using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;

    public Transform groundHolder;

    public Vector2Int mapDimensionsInPrefabs;
    private void Start()
    {
        float scale = groundPrefab.transform.localScale.x * 10;

        for (int x = -mapDimensionsInPrefabs.x; x <= mapDimensionsInPrefabs.x; x++)
        {
            for (int y = -mapDimensionsInPrefabs.y; y <= mapDimensionsInPrefabs.y; y++)
            {
                GameObject newGround = Instantiate(groundPrefab, groundHolder);

                newGround.transform.localPosition = new Vector3(x * scale, 0, y * scale);
            }
        }
    }
}
