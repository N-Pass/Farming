using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public static CurrencyController instace;

    public float currentMoney;

    private void Awake()
    {
        if(instace == null)
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UIController.instance.UpdateMoneyText(currentMoney);
    }

    public void SpendMoney(float amountToSpend)
    {
        currentMoney -= amountToSpend;

        UIController.instance.UpdateMoneyText(currentMoney);
    }

    public void AddMoney(float amountToAdd)
    {
        currentMoney += amountToAdd;

        UIController.instance.UpdateMoneyText(currentMoney);
    }

    public bool CheckMoney(float amount)
    {
        if(currentMoney >= amount)
        {
            return true;
        }

        return false;
    }
}
