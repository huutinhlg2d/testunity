using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KleeMove : MonoBehaviour
{
    float TotalJumpDelaySeconds = 0.5f;
    float elapsedJumpDelaySeconds = 0.0f;

    // Update is called once per frame
    void Update()
    {
        elapsedJumpDelaySeconds += Time.deltaTime;
        float xImpulse = Random.Range(0.0f, 2);
        float yImpulse = Random.Range(0.0f, 2);
        Debug.Log(xImpulse + " " + yImpulse);
        if (elapsedJumpDelaySeconds >= TotalJumpDelaySeconds)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(xImpulse, yImpulse), ForceMode2D.Force);
        }

    }
}
