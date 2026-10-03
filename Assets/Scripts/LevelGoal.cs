using UnityEngine;
using UnityEngine.UI;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] private GameObject completeMessage;

    private bool completed;

    private void OnTriggerEnter(Collider other)
    {
        if (completed || !other.CompareTag("Player"))
            return;

        completed = true;

        if (completeMessage != null)
            completeMessage.SetActive(true);

        Debug.Log("Level 1 complete!");
    }
}