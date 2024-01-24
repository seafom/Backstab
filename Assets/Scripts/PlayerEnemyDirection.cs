using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDirection : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);

    }
}