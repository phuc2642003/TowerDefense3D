using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    [SerializeField] private int batteries = 100;

    public override void Awake()
    {
        base.Awake();
    }

    public int Batteries
    {
        get => batteries;
        set
        {
            batteries = value;
            UpdateCurrencyUI();
        }
    }

    void Start()
    {
        UpdateCurrencyUI(); 
    }
    public void SpendCurrency(int amount)
    {
        batteries -= amount;
        UpdateCurrencyUI();
    }

    public void GetCurrency(int amount)
    {
        batteries += amount;
        UpdateCurrencyUI();
    }
    private void UpdateCurrencyUI()
    {
        GUIManager.Instance.batteriesText.text = batteries.ToString();
    }

}
