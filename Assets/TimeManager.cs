using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public bool isSlowMotion = false;

    public float slowMotionMultiplier = 0.3f;

    public float slowMotionDuration = 2f;

    private float slowMotionTimer = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isSlowMotion)
        {
            slowMotionTimer -= Time.deltaTime;

            if (slowMotionTimer <= 0f)
            {
                isSlowMotion = false;
            }
        }
    }

    public void ActivateSlowMotion()
    {
        isSlowMotion = true;
        slowMotionTimer = slowMotionDuration;
    }

    public float GetSpeed(float normalSpeed)
    {
        if (isSlowMotion)
        {
            return normalSpeed * slowMotionMultiplier;
        }

        return normalSpeed;
    }
}