using UnityEngine;

public class PatrolHazard : MonoBehaviour
{
    [SerializeField] private Transform waypointA;
    [SerializeField] private Transform waypointB;
    [SerializeField] private float speed = 2f;

    private Transform target;

    private void Start()
    {
        target = waypointB;
    }

    private void Update()
    {
        if (waypointA == null || waypointB == null)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
            target = target == waypointA ? waypointB : waypointA;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Rigidbody playerRb = other.GetComponentInParent<Rigidbody>();

        if (playerRb != null)
        {
            playerRb.velocity = Vector3.zero;
            playerRb.position = new Vector3(0f, 1f, -12f);
        }
        else
        {
            other.transform.root.position = new Vector3(0f, 1f, -12f);
        }

        Debug.Log("Hazard hit! Returning to the start.");
    }
}