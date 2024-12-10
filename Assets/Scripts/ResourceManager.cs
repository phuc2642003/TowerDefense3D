using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    private int batteries;

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
        throw new System.NotImplementedException();
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
