﻿
using UnityEngine;

public class LightPlayerController : MonoBehaviour
{

    [SerializeField] private LayerMask whatIsGround;  // A mask determining what is ground to the character
    const float groundedRadius = 0.5f;                // Radius of the overlap circle to determine if grounded
    private bool grounded;                            // Whether or not the player is grounded.
    private bool jump;


    [SerializeField] private float jumpForce = 400f;    // Amount of force added when the player jumps.
    [SerializeField] private Transform groundCheck;     // A position marking where to check if the player is grounded.

    float horizontalMove = 0f;
    private Rigidbody2D rigidbody2D;
    private Vector3 velocity = Vector3.zero;
    private bool facingRight = true;             // For determining which way the player is currently facing.
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;  // How much to smooth out the movement
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = 0.0f;
        if (Input.GetKey(GameManager.GM.PlayerTwoForward))
        {
            horizontalMove += moveSpeed;

        }
        if (Input.GetKey(GameManager.GM.PlayerTwoBackward))
        {
            horizontalMove -= moveSpeed;
        }

        if (Input.GetKeyDown(GameManager.GM.PlayerTwoAbility))
        {
            Debug.Log("SAUT");
            jump = true;
        }

    }

    void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }
        Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }


    private void Move(float move, bool jump)
    {

        Vector3 targetVelocity = new Vector2(move * 10f, GetComponent<Rigidbody2D>().velocity.y);
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }

        if (grounded && jump)
        {
            // Add a vertical force to the player.
            grounded = false;
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}