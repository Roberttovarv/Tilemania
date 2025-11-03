using UnityEngine;
using UnityEngine.InputSystem;

public class HarryController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rigidBody;
    SpriteRenderer sprite;
    Animator myAnimator;

    float runVelocity = 5f;

    bool isRunning;
    bool isClimbing;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Iddle();
    }

    void FixedUpdate()
    {
        Run();        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        print(moveInput);
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
}
