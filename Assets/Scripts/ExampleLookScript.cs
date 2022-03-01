using UnityEngine;

public class ExampleLookScript : MonoBehaviour
{
    public enum Mode
    {
        LookAwayInstant,
        LookAwaySlow,
        LookTowardInstant,
        LookTowardSlow
    }

    public GameObject viewTarget;
    public Mode lookMode;

    public float turnTime = 2f;

    private float elapsed = 0f;
    private Vector3 lastTargetPosition;
    private Quaternion lookStartOrientation;
    private Quaternion? lookEndOrientation;

    void Update()
    {
        if (viewTarget.transform.position != lastTargetPosition)
        {
            elapsed = 0f;
            lastTargetPosition = viewTarget.transform.position;
            lookStartOrientation = transform.rotation;
            lookEndOrientation = null;
        }

        elapsed = Mathf.Min(elapsed + Time.deltaTime, turnTime); // Either add time, or sit at max if the target is stationary


        switch (lookMode)
        {
            case Mode.LookTowardInstant:
                transform.LookAt(viewTarget); // Added a LookAt for a GameObject, instead of just the transform
                break;

            case Mode.LookAwayInstant:
                transform.LookAwayFrom(viewTarget); // Works like LookAt, but looks away, handy for quads
                break;

            case Mode.LookAwaySlow:
                if (lookEndOrientation == null) lookEndOrientation = transform.GetLookAwayFromRotation(viewTarget);
                transform.rotation = Quaternion.Slerp(lookStartOrientation, lookEndOrientation.Value, elapsed / turnTime);
                break;

            case Mode.LookTowardSlow:
                if (lookEndOrientation == null) lookEndOrientation = transform.GetLookAtRotation(viewTarget);
                transform.rotation = Quaternion.Slerp(lookStartOrientation, lookEndOrientation.Value, elapsed / turnTime);
                break;
        }
    }
}
