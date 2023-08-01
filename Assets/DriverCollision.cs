using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverCollision : MonoBehaviour
{

    bool hasPackage;
    //timeTillDestroy = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("ouch!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            Debug.Log("Picked up package!");
            hasPackage = true;
            Destroy(collision.gameObject);
        }else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered to customer!");
            hasPackage = false;
        }else
        {
            Debug.Log("You dont have the package");
        }
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("slowed");
    //}
}
