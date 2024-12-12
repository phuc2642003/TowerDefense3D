using UnityEngine;
using TMPro;
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private TMP_Text priceText;

    public void UpdateText(int price)
    {
        priceText.text = price.ToString();
    }
}
