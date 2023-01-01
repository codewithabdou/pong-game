using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You lose");
    }
}
