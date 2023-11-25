using UnityEngine;

public class TowerBuyPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _towerGameObject;

    [SerializeField]
    private int _towerCost;
    
    private PlayerMoney _playerMoney;
    private MoveToAim _moveToAim;
    
    private void Start()
    {
        _playerMoney = FindFirstObjectByType<PlayerMoney>();
        _moveToAim = FindFirstObjectByType<MoveToAim>();
    }

    public void TurnOnPlacingTower()
    {
        _towerGameObject.SetActive(true);
        _moveToAim.SetObjectOnCursor(_towerGameObject.transform);
    }
    
    private void Buy()
    {
        _playerMoney.TrySpendMoney(_towerCost);
    }
}