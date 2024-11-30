using UnityEngine;

public class ShopController : MonoBehaviour
{
    public ShopSeedDisplay[] seeds;
    public ShopCropDisplay[] crops;

    public void OpenClose()
    {
        if(UIController.instance.theIC.gameObject.activeSelf == false)
        {
            gameObject.SetActive(!gameObject.activeSelf);

            if(gameObject.activeSelf == true)
            {
                foreach (ShopSeedDisplay seed in seeds)
                {
                    seed.UpdateDisplay();
                }

                foreach (ShopCropDisplay crop in crops)
                {
                    crop.UpdateDisplay();
                }
            }
        }
    }
}
