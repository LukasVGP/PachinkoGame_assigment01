using UnityEngine;

public class PegWobble : MonoBehaviour
{
    [SerializeField] private float wobbleAmount = 5f;
    [SerializeField] private float wobbleSpeed = 2f;
    private Vector3 startRotation;

    void Start()
    {
        startRotation = transform.eulerAngles;
    }

    void Update()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        transform.eulerAngles = startRotation + new Vector3(0, 0, wobble);
    }
}
