using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    [SerializeField] private int batteries = 100;

    public int Batteries
    {
        get => batteries;
        set => batteries = value;
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
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
