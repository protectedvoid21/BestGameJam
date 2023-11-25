using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private int _startingMoney = 50;

    private int _money;
    
    [SerializeField]
    private TextMeshProUGUI _moneyText;

    private void Start()
    {
        _money = _startingMoney;
        AdjustUIMoney();
    }
    
    private void AdjustUIMoney()
    {
        _moneyText.text = "$ " + _money;
    }
    
    public void AddMoney(int amount)
    {
        _money += amount;
        AdjustUIMoney();
    }

    public bool CanSpendMoney(int amount)
    {
        return _money >= amount;
    }
    
    public bool TrySpendMoney(int amount)
    {
        if (CanSpendMoney(amount))
        {
            _money -= amount;
            AdjustUIMoney();
            return true;
        }

        return false;
    }
}