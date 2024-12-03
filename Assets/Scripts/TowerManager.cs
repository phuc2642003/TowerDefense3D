using Unity.VisualScripting;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public bool IsSelected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnMouseDown()
    {
        SelectionManager.Instance.SelectTower(this);
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
