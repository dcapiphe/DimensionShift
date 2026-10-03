using UnityEngine;

public class ScaleSensitiveHazard : MonoBehaviour
{
    [SerializeField] private float safeScale = 0.6f;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody playerRb = other.GetComponentInParent<Rigidbody>();

        if (playerRb == null || !playerRb.CompareTag("Player"))
            return;

        if (playerRb.transform.localScale.x <= safeScale)
        {
            Debug.Log("Laser passed safely while shrunk.");
            return;
        }

        if (respawnPoint != null)
            playerRb.position = respawnPoint.position;
        else
            playerRb.position = new Vector3(0f, 1f, -12f);

        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;

        Debug.Log("Too large for the laser! Returning to the start.");
    }
}