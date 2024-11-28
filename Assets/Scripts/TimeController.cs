using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public float currentTime;
    public float dayStarting;
    public float dayEnding;
    public float timeSpeed = .25f;

    private bool timeActive;
    public int currentDay = 1;
    public string dayEndScene;

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
        currentTime = dayStarting;

        timeActive = true;
    }

    private void Update()
    {
        if (timeActive)
        {
            currentTime += Time.deltaTime * timeSpeed;

            if (currentTime > dayEnding)
            {
                currentTime = dayEnding;
                EndDay();
            }

            if (UIController.instance != null)
            {
                UIController.instance.UpdateTimeText(currentTime);
            }
        }
    }

    public void EndDay()
    {
        timeActive = false;

        currentDay++;

        GridInfo.instance.GrowCrop();
        PlayerPrefs.SetString("Transition", "WakeUp");
        SceneManager.LoadScene(dayEndScene);
    }

    public void StartDay()
    {
        timeActive = true;
        currentTime = dayStarting;
    }
}
