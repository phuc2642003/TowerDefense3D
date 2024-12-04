using System;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private GameObject buyUI;
    [SerializeField] private GameObject buyButtonPrefab;
    [SerializeField] private float buttonRadius = 50f;

    private void Awake()
    {
        instance = this;
    }

    private TowerManager selectedTower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buyUI.SetActive(false);    
    }
    
    public void ShowBuyUI(TowerData[] towers, TowerManager tower)
    {   
        selectedTower = tower;

        foreach (Transform child in buyUI.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < towers.Length; i++)
        {
            GameObject newButton = Instantiate(buyButtonPrefab, buyUI.transform);
            newButton.transform.localPosition = GetBuyButtonPosition(i, towers.Length);
            Button buttonComponent = newButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.RemoveAllListeners();
                buttonComponent.onClick.AddListener(()=>BuyTower());
            }
        }
        
        buyUI.transform.position = Camera.main.WorldToScreenPoint(tower.gameObject.transform.position);
        buyUI.SetActive(true);
    }

    Vector3 GetBuyButtonPosition(int index, int numberOfButtons)
    {
        float angleStep = 360f / numberOfButtons;
        float angle = angleStep * index;
        float radiaangle = angle * Mathf.Deg2Rad;
        float xPos = Mathf.Sin(radiaangle) * buttonRadius;
        float yPos = Mathf.Cos(radiaangle) * buttonRadius;
        return new Vector3(xPos,yPos,0);
    }

    void BuyTower()
    {
        
    }
}
