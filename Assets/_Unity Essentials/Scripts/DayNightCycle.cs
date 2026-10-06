using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day/Night Cycle")]
    [Tooltip("How many real-world seconds it takes to complete one full day.")]
    [Min(0.1f)]
    public float dayDurationSeconds = 120f;

    private void Update()
    {
        // Degrees to rotate each second:
        // 360 degrees = one complete day.
        float rotationSpeed = 360f / dayDurationSeconds;

        // Rotate the Directional Light around the X axis.
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}