using Unity.VisualScripting;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] TowerData[] towers;
    public bool IsSelected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnMouseDown()
    {
        SelectionManager.instance.SelectTower(this);
        UIManager.instance.ShowBuyUI(towers,this);
        Debug.Log("Selected tower" +gameObject.name);
    }
    public void DeSelectTower()
    {
        IsSelected = false;
    }
    public void SelectTower()
    {
        IsSelected = true;
    }
}
