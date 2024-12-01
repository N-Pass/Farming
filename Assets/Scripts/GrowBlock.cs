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
    public CropController.CropType cropType;
    public float growFailChance;

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
            AudioManager.instance.PlaySFXPitchAdjusted(4);
        }
    }

    public void WaterSoil()
    {
        if (preventUse) return;
        isWatered = true;
        SetSoilSprite();
        AudioManager.instance.PlaySFXPitchAdjusted(7);
    }

    public void PlantCrop(CropController.CropType cropToPlant)
    {
        if(currentStage == GrowthStage.ploughed && isWatered && !preventUse)
        {
            currentStage = GrowthStage.planted;
            cropType = cropToPlant;

            growFailChance = CropController.instance.GetCropInfo(cropType).growthFailChance;
            CropController.instance.UseSeed(cropToPlant);
            UpdateCropSprite();

            AudioManager.instance.PlaySFXPitchAdjusted(3);
        }
    }

    public void UpdateCropSprite()
    {
        CropInfo activeCrop = CropController.instance.GetCropInfo(cropType);

        switch (currentStage)
        {
            case GrowthStage.planted:
                cropSR.sprite = activeCrop.planted;
                break;
            case GrowthStage.growing1:
                cropSR.sprite = activeCrop.growStage1;
                break;
            case GrowthStage.growing2:
                cropSR.sprite = activeCrop.growStage2;
                break;
            case GrowthStage.ripe:
                cropSR.sprite = activeCrop.ripe;
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
            CropController.instance.AddCrop(cropType);
            AudioManager.instance.PlaySFXPitchAdjusted(2);
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
