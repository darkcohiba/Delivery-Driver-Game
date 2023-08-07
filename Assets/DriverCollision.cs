using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverCollision : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 30, 255);
    [SerializeField] Color32 hasNoPackageColor = new Color32(250, 0, 0, 255);



    bool hasPackage;
    [SerializeField] float timeTillDestroy = 0.2f;

    SpriteRenderer spriteRenderer;

    //timer
    private float timer = 0.0f;
    private bool justDeliver = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Color32 currentColor = spriteRenderer.color;
        //Debug.Log(currentColor);

        
    }

    void Update()
    {
        if(justDeliver)
        {
            timer += Time.deltaTime;
        }

        if (!hasPackage && timer > 1.0f)
        {
            spriteRenderer.color = hasNoPackageColor;
            timer = 0.0f;
            justDeliver = false;
        }
    }

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

            //color update by our built in colors
            //spriteRenderer.color = hasPackageColor;

            //dynamic color update
            SpriteRenderer package = collision.gameObject.GetComponent<SpriteRenderer>();
            //Debug.Log(package.color);
            spriteRenderer.color = package.color;


            Destroy(collision.gameObject, timeTillDestroy);
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered to customer!");
            hasPackage = false;
            Destroy(collision.gameObject, timeTillDestroy);
            spriteRenderer.color = hasNoPackageColor;
            SpriteRenderer dropOff = collision.gameObject.GetComponent<SpriteRenderer>();
            //Debug.Log(package.color);
            spriteRenderer.color = dropOff.color;
            justDeliver = true;
            Destroy(collision.gameObject, timeTillDestroy);



        }
        else if (collision.tag == "Boost")
        {
            //spriteRenderer.

            Destroy(collision.gameObject, timeTillDestroy);

        }
        else
        {
            Debug.Log("You dont have the package");
        }
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("slowed");
    //}
}
