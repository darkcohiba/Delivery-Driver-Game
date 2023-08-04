using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverCollision : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 30, 255);
    [SerializeField] Color32 hasNoPackageColor = new Color32(250, 0, 0, 255);


    bool hasPackage;
    [SerializeField] float timeTillDestroy = 0.5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("ouch!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Picked up package!");
            hasPackage = true;
            Destroy(collision.gameObject, timeTillDestroy);
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
