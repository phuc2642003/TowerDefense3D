using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    [SerializeField] TMP_Text BuyPriceText;
    [SerializeField] Image TowerIcon;

    public void SetButton(Sprite Icon, int buyPrice)
    {
        if (TowerIcon.sprite != null)
        {
            TowerIcon.sprite = Icon;
        }
        else
        {
            TowerIcon.gameObject.SetActive(false);
        }

        if (BuyPriceText != null)
        {
            BuyPriceText.text = buyPrice.ToString();
        }
    }
}
