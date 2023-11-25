using System;
using UnityEngine;

public class ObjectToCursorFollower : MonoBehaviour
{
    private Camera _mainCamera;
    private Transform _objectOnCursor;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void SetObjectOnCursor(Transform objectTransform)
    {
        _objectOnCursor = objectTransform;
    }
    
    private void Update()
    {
        if (_objectOnCursor is null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _objectOnCursor.Rotate(0, 45, 0);
        }

        var ray =_mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000, LayerMask.GetMask("Ground")))
        {
            _objectOnCursor.position = hit.point;
        }
    }
}