using UnityEngine;
using UnityEngine.InputSystem;

public class HarryController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rigidBody;
    SpriteRenderer sprite;
    Animator myAnimator;
    [SerializeField] Collider2D bodyCollider;
    [SerializeField] Collider2D feetCollider;

    int floorLayer;

    float climbSpeed = 5f;
    bool isGrounded;
    bool IsOnLadder;

    bool isAlive = true;

    [SerializeField] float runVelocity = 5f;
    [SerializeField] float jumpForce = 10f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        floorLayer = LayerMask.GetMask("Floor");
    }

    void Update()
    {
        if (!isAlive) return;
        Iddle();
        ClimbLadder();
        Die();
    }

    void FixedUpdate()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) return;

        moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        rigidBody.linearVelocity = new Vector2(moveInput.x * runVelocity, rigidBody.linearVelocityY);

        sprite.flipX = rigidBody.linearVelocity.x < -0.1f ? true :
                rigidBody.linearVelocity.x > 0.1f ? false : sprite.flipX;

        myAnimator.SetBool("isRunning", true);

    }
    void Iddle()
    {
        if (rigidBody.linearVelocityX == 0)
        {
            myAnimator.SetBool("isRunning", false);
        }

    }

    void OnJump(InputValue value)
    {
        if (!isAlive) return;

        isGrounded = feetCollider.IsTouchingLayers(floorLayer);
        if (value.isPressed && (isGrounded || IsOnLadder))
        {
            rigidBody.linearVelocity += new Vector2(0f, jumpForce);
        }
    }
    void ClimbLadder()
    {
        IsOnLadder = bodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"));

        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            rigidBody.gravityScale = 0;

        }

        if (!IsOnLadder)
        {
            myAnimator.SetBool("isClimbing", false);
            rigidBody.gravityScale = 8;
            myAnimator.speed = 1;
            return;
        }
        if (isGrounded && IsOnLadder)
        {
            myAnimator.SetBool("isClimbing", false);

        }

        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocityX, moveInput.y * climbSpeed);
        rigidBody.gravityScale = 0;
        myAnimator.SetBool("isClimbing", true);

        myAnimator.speed = rigidBody.linearVelocityY == 0 ? 0 : 1;

    }
    void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            myAnimator.SetTrigger("isDead");
            isAlive = false;
            rigidBody.AddForce(new Vector2(Random.Range(-1f, 1f), 55f), ForceMode2D.Impulse);
            sprite.color = new Color(1f, 0.63f, 0.59f);
        }
    }
}
