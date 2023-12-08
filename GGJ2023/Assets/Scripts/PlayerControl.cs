using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    public int jumpCount = 1;
    private bool isJumping = false;
    private bool isCrouching = false;
    [SerializeField] private int jumpDistance = 10;
    [SerializeField] private LayerMask layerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected bool isGrounded()
    {
        Collider2D playerCollider = GetComponent<BoxCollider2D>();
        Vector2 raycastPos = playerCollider.bounds.center;
        float raycastDist = playerCollider.bounds.extents.y + 0.1f;

        RaycastHit2D hit = Physics2D.BoxCast(raycastPos, playerCollider.bounds.size, 0f, Vector2.down, raycastDist, layerMask);
        Color rayColor;
        if (hit.collider != null)
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

        return hit.collider != null;
    }

    private void Jump()
    {
        if (!isJumping && isGrounded() && (jumpCount > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
            isJumping = true;
            jumpCount--;
        }
        else if (isGrounded())
        {
            isJumping = false;
            jumpCount = 1;
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
            rb.velocity = new Vector2(rb.velocity.x, -jumpDistance);
        }
    }

    private void StopCrouch()
    {
        isCrouching = false;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2f, transform.localScale.z);
        //playerCollider.size = new Vector2(playerCollider.size.x, playerCollider.size.y * 2f);
        rb.gravityScale = 1;
    }

    void Update()
    {
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
    }
}
