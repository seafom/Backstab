using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float detectionRange = 10f;
    public float raycastDistance = 5f;

    void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the detection range
        if (distanceToPlayer < detectionRange)
        {
            // Perform a raycast in the player's direction
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (player.position - transform.position).normalized, out hit, raycastDistance))
            {
                // Check if the ray hits the player
                if (hit.collider.CompareTag("Player"))
                {
                    // Face the player
                    Vector3 direction = (player.position - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

                    // Move towards the player
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
            }
        }
    }
}
