using UnityEngine;

public class ScoringSlot : MonoBehaviour
{
    [SerializeField] private int pointValue = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ScoreManager.Instance.AddScore(pointValue);
            Destroy(other.gameObject);
        }
    }
}
