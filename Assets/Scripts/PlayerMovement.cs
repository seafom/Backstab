using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed, rotationSpeed;
    private Vector3 input;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Start()
    {

    }

    void Update()
    {
        input = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        Vector3 desiredRotation = new Vector3(0, input.x * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(desiredRotation));

        Vector3 movement = new Vector3(transform.forward.x * input.y * speed * Time.deltaTime, 0, transform.forward.z * input.y * speed * Time.deltaTime);
        rb.MovePosition(transform.position + movement);
    }
}