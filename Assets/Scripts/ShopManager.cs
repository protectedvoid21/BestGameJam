using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPanel;
    
    private void Start()
    {
        _shopPanel.SetActive(false);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _shopPanel.SetActive(true);
        }
    }
}
