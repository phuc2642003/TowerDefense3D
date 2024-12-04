using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance;
    
    public TowerManager selectedTower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    public void SelectTower(TowerManager tower)
    {
        if (selectedTower != null && selectedTower != tower)
        {
            DeselectCurrentTower();
        }
        selectedTower = tower;
        selectedTower.SelectTower();
    }

    public void DeselectCurrentTower()
    {
        if (selectedTower != null)
        {
            selectedTower.DeSelectTower();
            selectedTower = null;
        }
    }

}
