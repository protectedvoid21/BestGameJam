using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TowerBuyButton : MonoBehaviour
{
    private bool _currentlyPlacing;

    private Button _button;
    
    [SerializeField]
    private PlaceObject _towerPlaceObject;
    private PlaceObject _towerPlaceObjectInstance;

    [SerializeField]
    private int _towerCost;
    [SerializeField]
    private TextMeshProUGUI _costText;

    private bool CanPlayerAfford => _playerMoney.CanSpendMoney(_towerCost);
    
    private PlayerMoney _playerMoney;
    private ObjectToCursorFollower _objectToCursorFollower;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _playerMoney = FindFirstObjectByType<PlayerMoney>();
        _objectToCursorFollower = FindFirstObjectByType<ObjectToCursorFollower>();
        _costText.text = "$" + _towerCost;
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
        if (!CanPlayerAfford)
        {
            _button.interactable = false;
            return;
        }
        _button.interactable = true;
        
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
        TurnOffPlacingTower();
        if (!CanPlayerAfford)
        {
            return;
        }
        var isPlaceSucceed = _towerPlaceObjectInstance.Place();
        if (isPlaceSucceed)
        {
            _playerMoney.TrySpendMoney(_towerCost);
        }
    }
}