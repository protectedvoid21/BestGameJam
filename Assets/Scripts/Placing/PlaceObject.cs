using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToPlace;

    [SerializeField]
    private MeshRenderer[] _meshRenderers;

    private bool _canPlace = true;
    
    private void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }
    
    public bool Place()
    {
        if (_canPlace)
        {
            Instantiate(_objectToPlace, transform.position, transform.rotation);
        }

        return _canPlace;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other is null || !_canPlace)
        {
            return;
        }

        _canPlace = false;
        foreach (var meshRenderer in _meshRenderers)
        {
            meshRenderer.material.color = Color.red;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other is null || _canPlace)
        {
            return;
        }
        
        foreach (var meshRenderer in _meshRenderers)
        {
            meshRenderer.material.color = Color.white;
        }
        _canPlace = true;
    }
}