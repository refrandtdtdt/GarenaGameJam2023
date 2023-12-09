using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    public int jumpCount = 1;
    public int maxJumpCount = 1;
    private bool isJumping = false;
    private bool isCrouching = false;
    [SerializeField ]private int defaultGravityScale = 2;
    [SerializeField] public int jumpDistance = 20;
    [SerializeField] private LayerMask layerMask;
    public PowerUp powerUp = new HighJump();

    private float timer = 0f;
    private float logInterval = 1f/4f; // Log interval in seconds

    void Start()
    {
        powerUp = new HighJump();
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected bool isGrounded()
    {
        Collider2D playerCollider = GetComponent<BoxCollider2D>();
        Vector2 raycastPos = playerCollider.bounds.center;
        float raycastDist = playerCollider.bounds.extents.y;

        RaycastHit2D hit = Physics2D.BoxCast(raycastPos, playerCollider.bounds.size, 0.5f, Vector2.down, raycastDist, layerMask);
        Color rayColor;
        if (hit.collider != null && hit.normal.x == 0)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;

        }
        Debug.DrawRay(raycastPos + new Vector2(playerCollider.bounds.extents.x, 0), Vector2.down * raycastDist, rayColor);
        Debug.DrawRay(raycastPos - new Vector2(playerCollider.bounds.extents.x, 0), Vector2.down * raycastDist, rayColor);
        Debug.DrawRay(raycastPos - new Vector2(playerCollider.bounds.extents.x, raycastDist), 2 * raycastDist * Vector2.right, rayColor);
         
        return hit.collider != null && hit.normal.x == 0;
    }

    private void Jump()
    {
        if (jumpCount <= 0 || isJumping) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
        jumpCount--;
        if ((!isJumping && isGrounded()))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
            isJumping = true;
            jumpCount--;
        }
    }

    private void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            Vector3 originalPosition = transform.position;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y* 0.5f, transform.localScale.z);
            //playerCollider.size = new Vector2(playerCollider.size.x, playerCollider.size.y / 2f);
            Vector3 newPosition = originalPosition - new Vector3(0f, playerCollider.size.y * 0.25f, 0f);
            transform.position = newPosition;
            rb.velocity = new Vector2(rb.velocity.x, -2*jumpDistance);
        }
    }

    private void StopCrouch()
    {
        isCrouching = false;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2f, transform.localScale.z);
        //playerCollider.size = new Vector2(playerCollider.size.x, playerCollider.size.y * 2f);
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        rb.gravityScale = defaultGravityScale;
    }

    void Update()
    {
        //print maxJumpCount every seconds
        timer += Time.deltaTime;

        if (timer >= logInterval)
        {
            Debug.Log("JumpCount: " + jumpCount);
            timer = 0f; // Reset the timer
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            Jump();

        }
        
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Crouch();
        }
        else if (isCrouching)
        {
            StopCrouch();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            powerUp.ApplyEffect(this);
        }
        
    }

    private void FixedUpdate()
    {
        if (isGrounded())
        {
            jumpCount = maxJumpCount;
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (powerUp is CoinMagnet)
        {
            if (((CoinMagnet)powerUp).IsActivated)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, ((CoinMagnet)powerUp).magnetRadius);
            }
            
        }
    }
}
