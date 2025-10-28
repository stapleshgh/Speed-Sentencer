using System.Collections;
using UnityEngine;

public class AccusedBabyMove : MonoBehaviour
{
    public Transform targetPosition;
    public float WaitTime = 4f; // Time to wait before starting lerping
    public float lerpTime = 2f; // Time taken to reach the target position

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(StartLerping(WaitTime));
    }

    IEnumerator StartLerping(float waittime)
    {
        yield return new WaitForSeconds(WaitTime); // Wait for 4 seconds

        float elapsedTime = 0f;

        while (elapsedTime < lerpTime)
        {
            float t = elapsedTime / lerpTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition.position; // Ensure object reaches exactly at target position
        
    }
    
}
