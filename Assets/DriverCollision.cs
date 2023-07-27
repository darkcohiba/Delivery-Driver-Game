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
        if (collision.tag == "Package")
        {
            Debug.Log("Picked up package!");
        }else if (collision.tag == "Customer")
        {
            Debug.Log("Package delivered to customer!");
        }
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("slowed");
    //}
}
