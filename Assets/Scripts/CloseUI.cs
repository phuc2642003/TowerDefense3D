using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public void Close()
    {
        SelectionManager.Instance.DeselectCurrentTower();
    }
    
}
