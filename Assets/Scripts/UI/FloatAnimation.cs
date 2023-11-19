using UnityEngine;
using UnityEngine.UI;

public class FloatAnimation : MonoBehaviour
{
    public float amplitude = 0.1f;
    public float frequency = 1f;
    public float rotationSpeed = 10f;
    public float maxRotation = 30f;

    private RectTransform rectTransform;
    private Vector3 initialPosition;
    private bool rotateLeft = true;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.localPosition;
    }

    private void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        rectTransform.localPosition = initialPosition + new Vector3(0f, y, 0f);

        if (rotateLeft)
        {
            rectTransform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            if (rectTransform.localRotation.eulerAngles.z >= maxRotation && rectTransform.localRotation.eulerAngles.z <= 180)
            {
                rotateLeft = false;
            }
        }
        else
        {
            rectTransform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
            if (rectTransform.localRotation.eulerAngles.z <= 360 - maxRotation && rectTransform.localRotation.eulerAngles.z >= 180)
            {
                rotateLeft = true;
            }
        }
    }
}
