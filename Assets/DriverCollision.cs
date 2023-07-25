using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("ouch!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("speed!");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("slowed");
    }
}
