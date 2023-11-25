using UnityEngine;

public class TowerBuyPanel : MonoBehaviour
{
    private bool _currentlyPlacing;
    
    [SerializeField]
    private PlaceObject _towerPlaceObject;
    private PlaceObject _towerPlaceObjectInstance;

    [SerializeField]
    private int _towerCost;
    
    private PlayerMoney _playerMoney;
    private ObjectToCursorFollower _objectToCursorFollower;
    
    private void Start()
    {
        _playerMoney = FindFirstObjectByType<PlayerMoney>();
        _objectToCursorFollower = FindFirstObjectByType<ObjectToCursorFollower>();
    }

    public void TurnOnPlacingTower()
    {
        _currentlyPlacing = true;
        _towerPlaceObjectInstance = Instantiate(_towerPlaceObject);
        _objectToCursorFollower.SetObjectOnCursor(_towerPlaceObjectInstance.transform);
    }
    
    private void TurnOffPlacingTower()
    {
        _currentlyPlacing = false;
        _objectToCursorFollower.SetObjectOnCursor(null);
        Destroy(_towerPlaceObjectInstance.gameObject);
    }

    private void Update()
    {
        if (!_currentlyPlacing)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Buy();
        }
        if (Input.GetMouseButtonDown(1))
        {
            TurnOffPlacingTower();
        }
    }
    
    private void Buy()
    {
        _playerMoney.TrySpendMoney(_towerCost);
        _towerPlaceObjectInstance.Place();
        Destroy(_towerPlaceObjectInstance.gameObject);
        
        TurnOffPlacingTower();
    }
}