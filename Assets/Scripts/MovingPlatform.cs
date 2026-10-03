using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;

    private Rigidbody rb;
    private Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = pointB;
    }

    private void FixedUpdate()
    {
        if (pointA == null || pointB == null || target == null)
            return;

        Vector3 nextPosition = Vector3.MoveTowards(
            rb.position,
            target.position,
            speed * Time.fixedDeltaTime
        );

        rb.MovePosition(nextPosition);

        if (Vector3.Distance(nextPosition, target.position) < 0.05f)
            target = target == pointA ? pointB : pointA;
    }
}