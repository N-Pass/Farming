using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSeedDisplay : MonoBehaviour
{
    public CropController.CropType crop;

    public Image seedImage;
    public TMP_Text seedAmount, priceText;

    public void UpdateDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        seedImage.sprite = info.seedType;
        seedAmount.text = "x " + info.seedAmount;

        priceText.text = "$" + info.seedPrice + " each";
    }

    public void BuySeed(int amount)
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        if(CurrencyController.instace.CheckMoney(info.seedPrice * amount))
        {
            CropController.instance.AddSeed(crop, amount);

            CurrencyController.instace.SpendMoney(info.seedPrice * amount);

            UpdateDisplay();
        }
    }
}
