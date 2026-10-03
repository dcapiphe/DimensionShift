using UnityEngine;

public class RotatingFactoryHazard : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private Transform respawnPoint;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody playerRb = other.GetComponentInParent<Rigidbody>();

        if (playerRb == null || !playerRb.CompareTag("Player"))
            return;

        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
        playerRb.position = respawnPoint != null
            ? respawnPoint.position
            : new Vector3(0f, 1f, -12f);

        Debug.Log("Factory hazard hit! Returning to the start.");
    }
}