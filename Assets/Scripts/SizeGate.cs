using UnityEngine;

public class SizeGate : MonoBehaviour
{
    [SerializeField] private float maxAllowedScale = 0.6f;
    [SerializeField] private GameObject tooLargeMessage;

    private void OnTriggerEnter(Collider other)
    {
        Transform player = other.transform.root;

        if (!player.CompareTag("Player"))
            return;

        bool isSmallEnough = player.localScale.x <= maxAllowedScale;

        if (tooLargeMessage != null)
            tooLargeMessage.SetActive(!isSmallEnough);

        Debug.Log(isSmallEnough
            ? "Size gate passed."
            : "Shrink to pass through the gate.");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.root.CompareTag("Player"))
            return;

        if (tooLargeMessage != null)
            tooLargeMessage.SetActive(false);
    }
}