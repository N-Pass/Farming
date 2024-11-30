using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject[] toolbarActivatorIcons;
    public TMP_Text timeText;

    public InventoryController theIC;
    public ShopController theShop;

    public Image seedImage;

    public TMP_Text moneyText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SwitchTool(0);
    }
    private void Update()
    {
        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            theIC.OpenClose();
        }

#if UNITY_EDITOR
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            theShop.OpenClose();
        }

#endif
    }

    public void SwitchTool(int selected)
    {
        foreach (GameObject icon in toolbarActivatorIcons)
        {
            icon.SetActive(false);
        }

        toolbarActivatorIcons[selected].SetActive(true);
    }


    public void UpdateTimeText(float currentTime)
    {
        if (currentTime < 12)
        {
            timeText.text = Mathf.FloorToInt(currentTime) + "AM";
        }
        else if(currentTime < 13)
        {
            timeText.text = "12PM";
        }
        else if(currentTime < 24)
        {
            timeText.text = Mathf.FloorToInt(currentTime - 12) + "PM";
        }
        else if(currentTime < 25)
        {
            timeText.text = "12AM";
        }
        else
        {
            timeText.text = Mathf.FloorToInt(currentTime - 24) + "AM";
        }
    }

    public void SwitchSeed(CropController.CropType crop)
    {
        seedImage.sprite = CropController.instance.GetCropInfo(crop).seedType;
    }

    public void UpdateMoneyText(float currentMoney)
    {
        moneyText.text = "$" + currentMoney;
    }
}
