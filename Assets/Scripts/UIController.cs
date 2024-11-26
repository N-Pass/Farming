using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject[] toolbarActivatorIcons;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SwitchTool(0);
    }

    public void SwitchTool(int selected)
    {
        foreach (GameObject icon in toolbarActivatorIcons)
        {
            icon.SetActive(false);
        }

        toolbarActivatorIcons[selected].SetActive(true);
    }
}
