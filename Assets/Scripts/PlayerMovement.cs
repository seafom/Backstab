using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed, rotationSpeed;
    private Vector3 input;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

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
           
        }
    }
}
