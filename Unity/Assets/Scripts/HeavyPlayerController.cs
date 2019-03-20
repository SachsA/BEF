using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPlayerController : MonoBehaviour
{

    public Animator animator;

    float horizontalMove = 0f;
    private Rigidbody2D rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    private bool facingRight = true;  // For determining which way the player is currently facing.


    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
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
        if (Input.GetKey(GameManager.GM.PlayerOneForward))
        {
            horizontalMove += moveSpeed;

        }
        if (Input.GetKey(GameManager.GM.PlayerOneBackward))
        {
            horizontalMove -= moveSpeed;
        }

        animator.SetFloat("moveSpeed", Mathf.Abs(horizontalMove));
    }

    void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime);
    }


    private void Move(float move)
    {

        Vector3 targetVelocity = new Vector2(move * 10f, GetComponent<Rigidbody2D>().velocity.y);
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

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
