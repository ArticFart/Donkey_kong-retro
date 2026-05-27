using UnityEngine;
public class Barrel : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 4f;

    [SerializeField] private int damage = 1;

    private Rigidbody2D rb;

    private int moveDirection = 1;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {    
        Roll();  
    }

    private void Roll()
    {
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TurnAround"))
        {
            moveDirection *= -1;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}