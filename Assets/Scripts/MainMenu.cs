using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelStart;

    private void Start()
    {
        AudioManager.instance.PlayTitle();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(levelStart);
        AudioManager.instance.PlayNextBGM();

        AudioManager.instance.PlaySFXPitchAdjusted(5);
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.instance.PlaySFXPitchAdjusted(5);
    }        
}
