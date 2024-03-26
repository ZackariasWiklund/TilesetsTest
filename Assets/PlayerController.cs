using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    bool isJumping = false;
    bool canJump = true; // Control jump cooldown
    bool isGrounded = false; // track if grounded
    string lastDirection = "right";

    [SerializeField] float moveSpeed = 5f; // Adjust as needed
    [SerializeField] float jumpForce = 10f; // Adjust as needed
    [SerializeField] float jumpCooldown = 0.5f; // Cooldown duration between jumps

    void Update()
    {
        // Movement
        if (isGrounded || !isJumping) // Allow movement if grounded or not jumping
            transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Check for jump input
        if (canJump && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            canJump = false; // Disable jumping temporarily
            Invoke(nameof(ResetJump), jumpCooldown); // Reset jump after cooldown
        }

        // Apply jump force if jumping
        if (isJumping)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            isJumping = false;
        }

        // Can move in the air 
        if (movement.x < 0)
        {
            GetComponent<Animator>().Play("walkleft");
            lastDirection = "left";
        }
        else if (movement.x > 0)
        {
            GetComponent<Animator>().Play("walkright");
            lastDirection = "right";
        }
        else
        {
            if (lastDirection == "left") GetComponent<Animator>().Play("IdleLeft");
            if (lastDirection == "right") GetComponent<Animator>().Play("IdleRight");
        }
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    // Detect if the player collides with the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            SceneManager.LoadScene(1);
        }

    }

    // Detect if the player leaves the ground
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        
    }

    // Reset jump flag after cooldown
    void ResetJump()
    {
        canJump = true;
    }

      

}