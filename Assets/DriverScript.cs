using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowSpeed = 5f;
    //timer to move regular speed 3 seconds after accident
    bool justHit = false;
    float timer = 0.0f;
    //float moveAmount;


    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if (justHit && timer >= 3.0f)
        {
            moveSpeed = 15f;
            timer = 0.0f;
            justHit = false;
        }
        else if (justHit && timer < 3.0f)
        {
            timer += Time.deltaTime;
            Debug.Log("inside timers");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "WO")
        //{
        //    moveSpeed = slowSpeed;
        //    justHit = true;
        //}
        Debug.Log("bang hit");


        moveSpeed = slowSpeed;
        justHit = true;

    }
}
