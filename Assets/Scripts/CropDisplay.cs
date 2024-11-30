using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropDisplay : MonoBehaviour
{
    public CropController.CropType crop;
    public Image cropImage;
    public TMP_Text amountText;


    public void UpdateDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        cropImage.sprite = info.finalCrop;
        amountText.text = "x " + info.cropAmount;
    }
}
