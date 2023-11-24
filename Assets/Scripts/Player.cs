using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private CharacterController _characterController;

    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        var direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        _characterController.Move(direction * (_speed * Time.deltaTime));
    }
}
