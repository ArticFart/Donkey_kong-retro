using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    [SerializeField] private float climbSpeed = 5f;

    private bool isClimbingLadder = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isClimbingLadder)
        {
            float vertical = Input.GetAxisRaw("Vertical");

            rb.linearVelocity = new Vector2(0, vertical * climbSpeed);

            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbingLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbingLadder = false;
        }
    }
}