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
    public Sprite soilWatered;
    public SpriteRenderer cropSR;
    public Sprite cropPlanted;
    public Sprite cropGrowing1;
    public Sprite cropGrowing2;
    public Sprite cropRipe;

    public bool isWatered;
    public bool preventUse;

    private Vector2Int gridPosition; 

    private void Update()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
            AdvanceCrop();
    }
    public void AdvanceStage()
    {
        currentStage++;
        if ((int)currentStage >= 6)
            currentStage = GrowthStage.barren;
    }

    public void SetSoilSprite()
    {
        if (currentStage == GrowthStage.barren)
            theSR.sprite = null;
        else
        {
            if (isWatered)
                theSR.sprite = soilWatered;
            else
                theSR.sprite = soilTilled;
        }

        UpdateGridInfo();
    }

    public void PloughSoil()
    {
        if(currentStage == GrowthStage.barren && !preventUse)
        {
            currentStage = GrowthStage.ploughed;
            SetSoilSprite();
        }
    }

    public void WaterSoil()
    {
        if (preventUse) return;
        isWatered = true;
        SetSoilSprite();
    }

    public void PlantCrop()
    {
        if(currentStage == GrowthStage.ploughed && isWatered && !preventUse)
        {
            currentStage = GrowthStage.planted;
            UpdateCropSprite();
        }
    }

    public void UpdateCropSprite()
    {
        switch (currentStage)
        {
            case GrowthStage.planted:
                cropSR.sprite = cropPlanted;
                break;
            case GrowthStage.growing1:
                cropSR.sprite = cropGrowing1;
                break;
            case GrowthStage.growing2:
                cropSR.sprite = cropGrowing2;
                break;
            case GrowthStage.ripe:
                cropSR.sprite = cropRipe;
                break;
            default:
                break;
        }

        UpdateGridInfo();
    }

    public void AdvanceCrop()
    {
        if (isWatered && !preventUse)
        {
            if(currentStage == GrowthStage.planted || currentStage == GrowthStage.growing1 || currentStage == GrowthStage.growing2)
            {
                currentStage++;
                isWatered = false;
                SetSoilSprite();
                UpdateCropSprite();
            }
        }
    }

    public void HarvestCrop()
    {
        if(currentStage == GrowthStage.ripe && !preventUse)
        {
            currentStage = GrowthStage.ploughed;
            SetSoilSprite();
            cropSR.sprite = null;
        }
    }

    public void SetGridPosition(int x, int y)
    {
        gridPosition = new Vector2Int(x, y);
    }

    private void UpdateGridInfo()
    {
        GridInfo.instance.UpdateInfo(this, gridPosition.x, gridPosition.y);
    }
}
