using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;
    
    public TowerManager selectedTower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    public void SelectTower(TowerManager tower)
    {
        if (selectedTower != null && selectedTower != tower)
        {
            selectedTower.DeSelectTower();
        }
        selectedTower = tower;
        selectedTower.SelectTower();
    }

    public void DeselectTower()
    {
        if (selectedTower != null)
        {
            selectedTower.DeSelectTower();
            selectedTower = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
