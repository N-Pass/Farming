using UnityEngine;
using UnityEngine.InputSystem;

public class BedController : MonoBehaviour
{
    private bool canSleep;

    private void Update()
    {
        if (canSleep)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame 
                || Keyboard.current.spaceKey.wasPressedThisFrame
                || Keyboard.current.eKey.wasPressedThisFrame)
            {
                if(TimeController.instance != null)
                {
                    TimeController.instance.EndDay();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canSleep = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canSleep = false;
        }
    }
}
