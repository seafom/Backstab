using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Transform other;
    public TextMeshProUGUI popupText;
    private Vector3 dot;

    private bool isShowingText = false;

    void Start()
    {
        TextMeshPro popupText = gameObject.GetComponent<TextMeshPro>();
        if (popupText != null)
            popupText.enabled = false;
    }

    void Update()
    {
        if (other)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = other.position - transform.position;

            // Normalize the 'toOther' vector
            toOther.Normalize();

            // Calculate the dot product
            float dotProduct = Vector3.Dot(forward, toOther);

            if (dotProduct < 0)
            {
                if (!isShowingText)
                {
                    // Enable the text
                    if (popupText != null)
                        popupText.enabled = true;

                    // Start a coroutine to hide the text after 2 seconds
                    StartCoroutine(HideTextAfterDelay(1f));

                    print("The other transform is behind me!");
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