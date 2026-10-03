using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float speedMultiplier = 1f;

    [Header("Rotation")]
    public float rotationSpeed = 90f;

    [Header("Scaling")]
    public float scaleStep = 0.25f;
    public float minScale = 0.5f;
    public float maxScale = 2f;

    [Header("Speed Boost")]
    public float boostedSpeedMultiplier = 2f;

    private Rigidbody rb;

    private Vector3 currentScale;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentScale = transform.localScale;
    }

    void Update()
    {
        HandleRotation();
        HandleScaling();
        HandleSpeedBoost();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    // -----------------------------------
    // MOVEMENT - W/A/S/D
    // -----------------------------------

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 velocity = movement * moveSpeed * speedMultiplier;

        rb.velocity = new Vector3(
            velocity.x,
            rb.velocity.y,
            velocity.z
        );
    }

    // -----------------------------------
    // ROTATION - X KEY
    // -----------------------------------

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(
                0f,
                rotationSpeed * Time.deltaTime,
                0f
            );
        }
    }

    // -----------------------------------
    // SCALING - Y KEY
    // -----------------------------------

    void HandleScaling()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            float newScale = currentScale.x + scaleStep;

            if (newScale > maxScale)
            {
                newScale = minScale;
            }

            currentScale = new Vector3(
                newScale,
                newScale,
                newScale
            );

            transform.localScale = currentScale;
        }
    }

    // -----------------------------------
    // SPEED BOOST - K KEY
    // -----------------------------------

    void HandleSpeedBoost()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (speedMultiplier == 1f)
            {
                speedMultiplier = boostedSpeedMultiplier;
            }
            else
            {
                speedMultiplier = 1f;
            }
        }
    }
}