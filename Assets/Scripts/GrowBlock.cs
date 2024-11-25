using UnityEngine;
using UnityEngine.InputSystem;

public class GrowBlock : MonoBehaviour
{
    public enum GrowthStage
    {
        barren,
        ploughed,
        planted,
        growing1,
        growing2,
        ripe
    }

    public GrowthStage currentStage;
    public SpriteRenderer theSR;
    public Sprite soilTilled;


    private void Update()
    {
        
    }
    public void AdvanceStage()
    {
        currentStage += 1;
        if ((int)currentStage >= 6)
            currentStage = GrowthStage.barren;
    }

    public void SetSoilSprite()
    {
        if (currentStage == GrowthStage.barren)
            theSR.sprite = null;
        else
            theSR.sprite = soilTilled;
    }

    public void PloughSoil()
    {
        if(currentStage == GrowthStage.barren)
        {
            currentStage = GrowthStage.ploughed;
            SetSoilSprite();
        }
    }
}
