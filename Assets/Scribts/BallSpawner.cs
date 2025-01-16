using UnityEngine;
using TMPro;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float countdownTextSize = 200f;

    private bool isMovingRight = true;
    private bool isCountingDown = false;
    private float countdownTimer = 3f;

    void Start()
    {
        SetupCountdownText();
    }

    void SetupCountdownText()
    {
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false);
            countdownText.fontSize = countdownTextSize;
            countdownText.color = Color.red;

            RectTransform rectTransform = countdownText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.sizeDelta = new Vector2(400, 200);
        }
    }

    void Update()
    {
        MoveTriangle();

        if (Input.GetKeyDown(KeyCode.Space) && !isCountingDown)
        {
            StartCountdown();
        }

        if (isCountingDown)
        {
            HandleCountdown();
        }
    }

    void MoveTriangle()
    {
        float movement = isMovingRight ? moveSpeed * Time.deltaTime : -moveSpeed * Time.deltaTime;
        float newX = transform.position.x + movement;

        if (newX >= maxX)
        {
            isMovingRight = false;
            newX = maxX;
        }
        else if (newX <= minX)
        {
            isMovingRight = true;
            newX = minX;
        }

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void StartCountdown()
    {
        isCountingDown = true;
        countdownTimer = 3f;
        countdownText.gameObject.SetActive(true);
    }

    void HandleCountdown()
    {
        countdownTimer -= Time.deltaTime;
        countdownText.text = Mathf.Ceil(countdownTimer).ToString();

        if (countdownTimer <= 0)
        {
            SpawnBall();
            countdownText.gameObject.SetActive(false);
            isCountingDown = false;
        }
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}
