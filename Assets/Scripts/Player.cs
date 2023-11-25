using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [HideInInspector]
    public Damageable damageable;

    public static Player Instance;

    [SerializeField]
    private float _speed = 5.0f;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    private CharacterController _characterController;

    public Transform flashlight;

    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        var direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        _characterController.Move(direction * _speed * Time.deltaTime);

        if (direction.magnitude > 0)
        {
            flashlight.transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, 0f);
        }
    }
}
