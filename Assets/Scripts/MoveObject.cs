using UnityEngine;

public class MoveObject : MonoBehaviour 
{
	void Update () {
        transform.Translate(0, 0, 2f * Mathf.Cos(Time.realtimeSinceStartup) * Time.deltaTime);
	}
}
