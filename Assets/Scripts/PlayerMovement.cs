using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
    private bool isJumping;
    private bool isGrounded;
    [HideInInspector]
    public bool isClimbing;
    private bool recupEpee;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public CapsuleCollider2D playercollider;


    public Animator animator;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public SpriteRenderer spriteRenderer;
    private float horizontalMovement;
    private float verticalMovement;
    public static PlayerMovement instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la sc�ne");
            return;
        }
        instance = this;
    }
    void Update()
    {



        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;
        

        if (Input.GetButtonDown("Jump") && isGrounded) // si la spacebar est press� et qu'on est au sol alors l'�tat de l'objet passe a "est en train de sauter"
        {
            isJumping = true;
        }



        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement, verticalMovement);
    }
    void MovePlayer(float _horizontalMovement,  float _verticalMovement)
    {
        if(!isClimbing)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }



        }
        else
        {
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
