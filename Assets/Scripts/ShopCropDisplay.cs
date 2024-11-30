using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCropDisplay : MonoBehaviour
{
    public CropController.CropType crop;

    public Image cropImage;
    public TMP_Text cropAmount, priceText;

    public void UpdateDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        cropImage.sprite = info.finalCrop;
        cropAmount.text = "x " + info.cropAmount;

        priceText.text = "$" + info.cropPrice + " each";
    }

    public void SellCrop()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);
        
        if(info.cropAmount > 0)
        {
            CurrencyController.instace.AddMoney(info.cropAmount * info.cropPrice);
            CropController.instance.RemoveCrop(crop);
            UpdateDisplay();
        }
    }
}
