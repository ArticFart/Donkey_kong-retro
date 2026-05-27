using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

    // Ground check settings
    [SerializeField] private Transform groundCheck; // assign a small child object at the player's feet in the Inspector
    [SerializeField] private float groundCheckRadius = 0.12f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded = false;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null)
            groundCheck = transform;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Fix: OverlapBox expects a Vector2 for size, not a float.
        isGrounded = Physics2D.OverlapBox(
            groundCheck.position,
            new Vector2(groundCheckRadius, groundCheckRadius),0f,groundLayer) != null;

        if (Input.GetKeyDown(KeyCode.X) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
