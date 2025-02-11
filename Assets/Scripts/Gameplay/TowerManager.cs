using Unity.VisualScripting;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] TowerData[] towers;
    public bool IsSelected = false;

    private TowerData currentTower;

    public TowerData CurrentTower
    {
        get => currentTower;
        set => currentTower = value;
    }

    int towerLevel = 0;
    public int TowerLevel { get => towerLevel; set => towerLevel = value; }

    GameObject towerInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnMouseDown()
    {
        SelectionManager.Instance.SelectTower(this);
        if (towerLevel > 0)
        {
            UIManager.Instance.ShowUpgradeUI(currentTower,this);
        }
        else
        {
            UIManager.Instance.ShowBuyUI(towers,this);
        }
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
        currentTower = tower;
        if (ResourceManager.Instance.Batteries >= currentTower.BuyCost)
        {
            //spend resource
            ResourceManager.Instance.SpendCurrency(currentTower.BuyCost);
            
            //instantiate tower
            towerInstance = Instantiate(tower.PrefabObjects[0], transform.position, Quaternion.identity);
            //
            towerLevel = 1;
            Debug.Log(this.name + ": Tower Level: " + towerLevel);
        }
        
        SelectionManager.Instance.DeselectCurrentTower();
    }

    public void UpgradeTower()
    {
        Debug.Log("UpgradeTower");
        if (towerLevel >=1 && towerLevel <3)
        {
            if (ResourceManager.Instance.Batteries >= currentTower.UpgradeCost[towerLevel - 1])
            {
                ResourceManager.Instance.SpendCurrency(currentTower.UpgradeCost[towerLevel - 1]);
                Destroy(towerInstance);
                towerLevel++;
                towerInstance = Instantiate(currentTower.PrefabObjects[towerLevel - 1], transform.position, Quaternion.identity);
                SelectionManager.Instance.DeselectCurrentTower();
            }
        }
    }

    public void SellTower()
    {
        Debug.Log("SellTower");
        ResourceManager.Instance.GetCurrency(GetSellValue(towerLevel));
        SelectionManager.Instance.DeselectCurrentTower();
        Destroy(towerInstance);
        towerLevel = 0;
    }

    public int GetSellValue(int towerLevel)
    {
        int buyValue = currentTower.BuyCost;
        if (towerLevel > 1)
        {
            for (int i = 1; i < towerLevel; i++)
            {
                buyValue += currentTower.UpgradeCost[i-1];
            }
        }
        
        return Mathf.RoundToInt(buyValue*0.75f);
    }
}
