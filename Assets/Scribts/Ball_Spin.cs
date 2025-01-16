using UnityEngine;

public class BallSpin : MonoBehaviour
{
    [SerializeField] private float spinForce = 200f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Add initial random spin
        rb.AddTorque(Random.Range(-spinForce, spinForce));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Add more spin on collision
        rb.AddTorque(Random.Range(-spinForce / 2, spinForce / 2));
    }
}
