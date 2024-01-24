using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed, rotationSpeed;
    [SerializeField] private int maxHealth = 5;
    private int currentHealth;
    private Vector3 input;
    private Rigidbody rb;

    public TextMeshProUGUI healthText; // Reference to the UI Text element

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    void Start()
    {
        // Make sure to assign the Text component to healthText in the Unity Editor
        if (healthText == null)
        {
            Debug.LogError("UI Text is not assigned to the healthText variable!");
        }
        else
        {
            UpdateHealthText();
        }
    }

    void Update()
    {

        input = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0f, UnityEngine.Input.GetAxis("Vertical"));
        input.Normalize();

    }

    private void FixedUpdate()
    {
        Vector3 desiredRotation = new Vector3(0, input.x * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(desiredRotation));

        Vector3 movement = new Vector3(transform.forward.x * input.z * speed * Time.deltaTime, 0, transform.forward.z * input.z * speed * Time.deltaTime);
        rb.MovePosition(transform.position + movement);

        input.Normalize();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
            UpdateHealthText(); // Update health text when the player takes damage
        }
    }

    void TakeDamage()
    {
        currentHealth--;

        // Check if the player is still alive
        if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Player Health: " + currentHealth);
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
