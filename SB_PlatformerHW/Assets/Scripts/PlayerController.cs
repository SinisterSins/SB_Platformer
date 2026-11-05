using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
            playerBody.linearVelocityY = inputForce.y * jumpForce;
            onGround = false;
        }
        else
        {
            onGround = Physics2D.OverlapCircle(groundChecker.position, checkSize, groundLayer);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death")) //When hitting death tag, level resets
        {
            Debug.Log("Hitting death tigger");
            SceneManager.LoadScene("GameScene");
        }

        if (other.gameObject.CompareTag("Win")) //when hitting win tag, loads win scene
        {
            Debug.Log("You're Winner");
            SceneManager.LoadScene("WinScene");
        }
    }
}
