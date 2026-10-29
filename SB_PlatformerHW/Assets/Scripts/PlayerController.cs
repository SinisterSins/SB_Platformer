using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveInput;

    public float speed;
    public float jumpForce;

    public Rigidbody2D playerBody;
    Vector2 inputForce;

    public Transform groundChecker;
    public float checkSize;
    public LayerMask groundLayer;

    bool onGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        inputForce = moveInput.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        //moves player left and right
        playerBody.linearVelocityX = inputForce.x * speed;

        //allows player to jump by checking button press and if onGround = true
        if(inputForce.y > 0 && onGround)
        {
            playerBody.linearVelocityY = inputForce.y * speed;
            onGround = false;
        }
        else
        {
            onGround = Physics2D.OverlapCircle(groundChecker.position, checkSize, groundLayer);
        }
    }
}
