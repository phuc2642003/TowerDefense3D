using Unity.VisualScripting;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] TowerData[] towers;
    public bool IsSelected = false;

    private TowerData currentTower;
    int towerLevel = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnMouseDown()
    {
        SelectionManager.Instance.SelectTower(this);
        UIManager.Instance.ShowBuyUI(towers,this);
        Debug.Log("Selected tower" +gameObject.name);
    }
    public void DeSelectTower()
    {
        IsSelected = false;
        
        UIManager.Instance.HideUI();
    }
    public void SelectTower()
    {
        IsSelected = true;
    }

    public void BuyTower(TowerData tower)
    {
        if (ResourceManager.Instance.Batteries >= currentTower.BuyCost)
        {
            //spend resource
            ResourceManager.Instance.SpendCurrency(currentTower.BuyCost);
            
            //instantiate tower
            
            //
            towerLevel = 1;
        }
        
        SelectionManager.Instance.DeselectCurrentTower();
    }
}
