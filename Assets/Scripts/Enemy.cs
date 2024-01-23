using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class Enemy : MonoBehaviour
{
    public Transform other;
    public TextMeshProUGUI popupText;

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

            if (Vector3.Dot(forward, toOther) < 0)
            {
                if (!isShowingText)
                {
                    // Enable the text
                    if (popupText != null)
                        popupText.enabled = true;

                    // Start a coroutine to hide the text after 2 seconds
                    StartCoroutine(HideTextAfterDelay(2f));

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
