using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaSwitcher : MonoBehaviour
{
    public string indoor;
    public string transitionName;

    public Transform startPoint;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Transition"))
        {
            if (PlayerPrefs.GetString("Transition") == transitionName)
            {
                PlayerController.instance.transform.position = startPoint.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(indoor);

            PlayerPrefs.SetString("Transition", transitionName);
        }
    }
}
