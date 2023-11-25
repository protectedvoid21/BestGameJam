using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToPlace;
    
    public void Place()
    {
        Instantiate(_objectToPlace, transform.position, transform.rotation);
    }
}