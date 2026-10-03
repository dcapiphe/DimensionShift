using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FactoryPatrolHazard : MonoBehaviour
{
    [SerializeField] private Transform waypointA;
    [SerializeField] private Transform waypointB;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float speed = 2f;

    private Rigidbody hazardRb;
    private Transform target;

    private void Awake()
    {
        hazardRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = waypointB;
    }

    private void FixedUpdate()
    {
        if (waypointA == null || waypointB == null || target == null)
            return;

        Vector3 nextPosition = Vector3.MoveTowards(
            hazardRb.position,
            target.position,
            speed * Time.fixedDeltaTime
        );

        hazardRb.MovePosition(nextPosition);

        if (Vector3.Distance(nextPosition, target.position) < 0.05f)
            target = target == waypointA ? waypointB : waypointA;
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

        Debug.Log("Patrol hazard hit! Returning to the Factory start.");
    }
}