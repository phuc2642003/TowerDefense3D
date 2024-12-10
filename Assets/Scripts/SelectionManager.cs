using UnityEngine;

public class SelectionManager : Singleton<SelectionManager>
{
    public TowerManager selectedTower;

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
