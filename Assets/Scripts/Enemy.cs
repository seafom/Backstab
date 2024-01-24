using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Transform other;
    public TextMeshProUGUI popupText;
    private Vector3 dot;

    private bool isShowingText = false;

    public float rotationSpeed = 30f; 


    void Start()
    {
        TextMeshPro popupText = gameObject.GetComponent<TextMeshPro>();
        if (popupText != null)
            popupText.enabled = false;
    }

    void Update()
    {
        // Rotate the enemy around its own Y-axis
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        if (other)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = other.position - transform.position;

            // Normalize the toOther' vector
            toOther.Normalize();

            float dotProduct = Vector3.Dot(forward, toOther);



            if (dotProduct < 0)
            {
                if (!isShowingText)
                {
                    // Enable the text
                    if (popupText != null)
                        popupText.enabled = true;

                    // Hide text for 1 second
                    StartCoroutine(HideTextAfterDelay(1f));

                    print("Player is behind me!");
                }
            }
        }
    }

    // Coroutine to hide the text after a delay
    private System.Collections.IEnumerator HideTextAfterDelay(float delay)
    {
        isShowingText = true;
        yield return new WaitForSeconds(delay);

        // Disable the text after the delay
        if (popupText != null)
            popupText.enabled = false;

        isShowingText = false;
    }

} 