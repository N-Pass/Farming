using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private readonly string SPEED = "speed";

    private Rigidbody2D theRB;
    private Animator anim;

    public float moveSpeed;
    public InputActionReference moveInput, actionInput;

    

    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //theRB.linearVelocity = new Vector2(moveSpeed, 0f);
        theRB.linearVelocity = moveInput.action.ReadValue<Vector2>().normalized * moveSpeed;
        
        if(theRB.linearVelocity.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(theRB.linearVelocity.x > 0f)
        {
            transform.localScale = Vector3.one;
        }

        if (actionInput.action.WasPressedThisFrame())
            UseTool();

        anim.SetFloat(SPEED, theRB.linearVelocity.magnitude);
    }

    private void UseTool()
    {
        GrowBlock block = null;

        block = FindFirstObjectByType<GrowBlock>();

        block.PloughSoil();
    }
}
