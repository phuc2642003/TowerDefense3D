using TMPro;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    [SerializeField] private TMP_Text priceText;

    public void UpdateText(int price)
    {
        priceText.text = price.ToString();
    }
}
