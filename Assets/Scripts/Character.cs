using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Character : MonoBehaviour
{
    [SerializeField] private Transform groundPt;
    private Rigidbody2D playerRb;

    private bool isGrounded;
    private float coyoteTime = 0.2f;
    private float coyoteCounter;
    private bool facingRight;
    private Vector2 inputVector;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (inputVector.x < 0 && facingRight)
        {
            FlipCharacter();
        }
        else if (inputVector.x > 0 && !facingRight)
        {
            FlipCharacter();
        }
    }

    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundPt.position, .2f, LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
        }

        if (isGrounded)
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.fixedDeltaTime;
        }
    }

    public void KonsolaBas()
    {
        Debug.Log("HelloHello");
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
