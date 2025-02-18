using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GUIManager : Singleton<GUIManager>
{
    [Header("Buy Content")]
    [SerializeField] private GameObject buyUI;
    [SerializeField] private GameObject buyButtonPrefab;
    [SerializeField] private float buttonRadius = 50f;
    
    [Header("Upgrade Content")]
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private GameObject sellButtonPrefab;
    [SerializeField] private GameObject upgradeButtonPrefab;
    
    [Header("HUD Contents")] 
    public GameObject gameOverUI;
    public GameObject gameWonUI;
    public GameObject startRoundUI;
    [Header("----------------------")] 
    public TMP_Text batteriesText;
    public TMP_Text waveText;
    public TMP_Text poiHealthText;
    
    private TowerManager selectedTower;

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameplayManager.Instance == null)
        {
            Debug.Log("Game Manager is null");
        }
        if (GUIManager.Instance == null)
        {
            Debug.Log("GUI Manager is null");
        }
        buyUI.SetActive(false);    
        upgradeUI.SetActive(false);
        gameOverUI.SetActive(false); 
        gameWonUI.SetActive(false);
        startRoundUI.SetActive(true);
    }
    
    public void ShowBuyUI(TowerData[] towers, TowerManager tower)
    {   
        buyUI.SetActive(true);
        selectedTower = tower;

        foreach (Transform child in buyUI.transform)
        {
            if (child.name != "CloseButton")
            {
                Destroy(child.gameObject);
            }
        }

        for (int i = 0; i < towers.Length; i++)
        {
            GameObject newButton = Instantiate(buyButtonPrefab, buyUI.transform);
            newButton.GetComponent<BuyButton>().SetButton(towers[i].Icon, towers[i].BuyCost);
            newButton.transform.localPosition = GetButtonPosition(i, towers.Length);
            Button buttonComponent = newButton.GetComponent<Button>();
            int index = i;
            if (buttonComponent != null)
            {
                buttonComponent.onClick.RemoveAllListeners();
                buttonComponent.onClick.AddListener(()=>tower.BuyTower(towers[index]));
            }
        }
        
        buyUI.transform.position = Camera.main.WorldToScreenPoint(tower.gameObject.transform.position);
        
    }

    Vector3 GetButtonPosition(int index, int numberOfButtons)
    {
        float angleStep = 360f / numberOfButtons;
        float angle = angleStep * index;
        float radiaangle = angle * Mathf.Deg2Rad;
        float xPos = Mathf.Sin(radiaangle) * buttonRadius;
        float yPos = Mathf.Cos(radiaangle) * buttonRadius;
        return new Vector3(xPos,yPos,0);
    }

    public void HideUI()
    {
        selectedTower = null;
        buyUI.SetActive(false);
        upgradeUI.SetActive(false);
    }

    public void ShowUpgradeUI(TowerData towerData,TowerManager tower)
    {
        upgradeUI.SetActive(true);
        selectedTower = tower;
        
        foreach (Transform child in upgradeUI.transform)
        {
            if (child.name != "CloseButton")
            {
                Destroy(child.gameObject);
            }
        }
        
        GameObject sellButton = Instantiate(sellButtonPrefab, upgradeUI.transform);
        sellButton.transform.localPosition = GetButtonPosition(1, 2);
        sellButton.GetComponent<SellButton>().UpdateText(tower.GetSellValue(tower.TowerLevel));
        Button sellButtonComponent = sellButton.GetComponent<Button>();
        if (sellButtonComponent != null)
        {
            sellButtonComponent.onClick.RemoveAllListeners();
            sellButtonComponent.onClick.AddListener(() => tower.SellTower());
        }

        if (tower.TowerLevel != tower.CurrentTower.PrefabObjects.Length)
        {
            GameObject upgradeButton = Instantiate(upgradeButtonPrefab, upgradeUI.transform);
            upgradeButton.transform.localPosition = GetButtonPosition(0, 2);
            upgradeButton.GetComponent<UpgradeButton>().UpdateText(towerData.UpgradeCost[tower.TowerLevel-1]);
            Button upgradeButtonComponent = upgradeButton.GetComponent<Button>();
            if (upgradeButtonComponent != null)
            {
                upgradeButtonComponent.onClick.RemoveAllListeners();
                upgradeButtonComponent.onClick.AddListener(() => tower.UpgradeTower());
            }
        }
        
        
        upgradeUI.transform.position = Camera.main.WorldToScreenPoint(tower.gameObject.transform.position);
    }

}
