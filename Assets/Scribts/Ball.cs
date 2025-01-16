using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 12f;
    [SerializeField] private float bounceForce = 2.5f;
    [SerializeField] private float randomForce = 0.5f;
    [SerializeField] private float downwardForce = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 2f; // Heavy metal ball
    }

    void FixedUpdate()
    {
        // Constant downward force
        rb.AddForce(Vector2.down * downwardForce);

        // Limit upward velocity severely
        if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.3f);
        }

        // Limit overall velocity
        if (rb.linearVelocity.magnitude > maxVelocity)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peg"))
        {
            Vector2 bounceDirection = (transform.position - collision.transform.position).normalized;
            // Emphasize horizontal movement
            bounceDirection.x *= 1.5f;
            bounceDirection.y = Mathf.Min(bounceDirection.y * 0.2f, 0);
            bounceDirection += new Vector2(Random.Range(-randomForce, randomForce), 0);
            rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }
}
