using UnityEngine;
using TMPro;

public class TransformationHUD : MonoBehaviour
{
    public Transform player;
    public PlayerController playerController;
    public TMP_Text telemetryText;

    void Update()
    {
        if (player == null || playerController == null || telemetryText == null)
            return;

        Vector3 scale = player.localScale;
        Vector3 rotation = player.eulerAngles;

        float speedMultiplier = playerController.speedMultiplier;

        string speedMode;

        if (speedMultiplier > 1f)
        {
            speedMode = "BOOST";
        }
        else
        {
            speedMode = "NORMAL";
        }

        telemetryText.text =
            "TRANSFORMATION\n\n" +

            "SCALE\n" +
            "X: " + scale.x.ToString("0.00") + "\n" +
            "Y: " + scale.y.ToString("0.00") + "\n" +
            "Z: " + scale.z.ToString("0.00") + "\n\n" +

            "ROTATION\n" +
            "X: " + rotation.x.ToString("0") + "°\n" +
            "Y: " + rotation.y.ToString("0") + "°\n" +
            "Z: " + rotation.z.ToString("0") + "°\n\n" +

            "SPEED\n" +
            "Multiplier: " + speedMultiplier.ToString("0.0") + "x\n" +
            "Mode: " + speedMode;
    }
}