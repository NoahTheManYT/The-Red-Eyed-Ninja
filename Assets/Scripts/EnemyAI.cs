using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float noiseDetectionRadius = 10f;
    public float visualConeAngle = 90f;
    public float visualConeDelay = 1f;
    public AudioClip deathSound;

    private Transform playerTransform;
    private AudioSource audioSource;
    private float lastVisualCheck;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check for noise in detection radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, noiseDetectionRadius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Look at player if noise is detected
                transform.LookAt(playerTransform);
                break;
            }
        }

        // Check for player within visual cone
        if (Time.time > lastVisualCheck + visualConeDelay)
        {
            lastVisualCheck = Time.time;
            Vector3 direction = playerTransform.position - transform.position;
            if (Vector3.Angle(direction, transform.forward) < visualConeAngle / 2)
            {
                float distance = Vector3.Distance(playerTransform.position, transform.position);
                if (Physics.Raycast(transform.position, direction, distance))
                {
                    // Player is in visual cone, take action (e.g. chase player)
                }
            }
        }
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw noise detection radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, noiseDetectionRadius);

        // Draw visual cone
        Gizmos.color = Color.red;
        Vector3 forward = transform.forward * 10f;
        Vector3 right = Quaternion.Euler(0, visualConeAngle / 2, 0) * forward;
        Vector3 left = Quaternion.Euler(0, -visualConeAngle / 2, 0) * forward;
        Gizmos.DrawLine(transform.position, transform.position + forward);
        Gizmos.DrawLine(transform.position, transform.position + right);
        Gizmos.DrawLine(transform.position, transform.position + left);
    }
}
