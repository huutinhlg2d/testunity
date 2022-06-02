using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    float minX = -8.16f,
        maxX = 8.16f,
        minY = -2.44f,
        maxY = 2.44f;

    float TotalJumpDelaySeconds = 0.2f;
    float elapsedJumpDelaySeconds = 0.0f;

    void Update()
    {
        elapsedJumpDelaySeconds += Time.deltaTime;
        Debug.Log(elapsedJumpDelaySeconds);
        if (elapsedJumpDelaySeconds >= TotalJumpDelaySeconds)
        {
            Debug.Log("Jump");
            elapsedJumpDelaySeconds = 0.0f;
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            transform.position = new Vector3(randomX, randomY, 0);
        }
    }
}
