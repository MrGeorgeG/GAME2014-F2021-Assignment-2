using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Touch Input")]
    public Joystick joystick;
    [Range(0.01f, 1.0f)]
    public float sensitivity;

    [Header("Movement")]
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    public Transform groundOrigin;
    public float groundRadius;
    public LayerMask groundLayerMask;
    [Range(0.1f, 0.9f)]
    public float airControlFactor;

    [Header("Animation")]
    public PlayerAnimationState state;

    public Rigidbody2D rigid;
    private Animator animController;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckIfGrounded();
    }

    private void Move()
    {
        float x = (Input.GetAxisRaw("Horizontal") + joystick.Horizontal) * sensitivity;

        if (isGrounded)
        {
            //Keyboard Input
            float y = (Input.GetAxisRaw("Vertical") + joystick.Vertical) * sensitivity;
            float jump = Input.GetAxisRaw("Jump") + ((UIContrroller.jumpButtonDown) ? 1.0f : 0.0f);

            //Check for Flip
            if (x != 0)
            {
                x = FlipAnimation(x);
                animController.SetInteger("AnimationState", (int)PlayerAnimationState.RUN);//Run state
                state = PlayerAnimationState.RUN;
            }
            else
            {
                animController.SetInteger("AnimationState", (int)PlayerAnimationState.IDLE);//Idle state AnimationStats
                state = PlayerAnimationState.IDLE;
            }

            float horizontalMoveForce = x * horizontalForce;
            float jumpMoveForce = jump * verticalForce;

            float mass = rigid.mass * rigid.gravityScale;

            rigid.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce) * mass);
            rigid.velocity *= 0.99f;// Scaling / stopping hack
        }
        else //Air Control
        {
            animController.SetInteger("AnimationState", (int)PlayerAnimationState.Jump);//Jump state
            state = PlayerAnimationState.Jump;

            if (x != 0)
            {
                x = FlipAnimation(x);

                float horizontalMoveForce = x * horizontalForce * airControlFactor;
                float mass = rigid.mass * rigid.gravityScale;

                rigid.AddForce(new Vector2(horizontalMoveForce, 0.0f) * mass);
            }
        }
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);

        isGrounded = (hit) ? true : false;
    }

    private float FlipAnimation(float x)
    {
        // depending on direction scale acress the x-axis either 1 or -1
        x = (x > 0) ? 1 : -1;

        transform.localScale = new Vector3(x, 1.0f);
        return x;

    }

    //EVENTS
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

    //UTILITIES
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }
}
