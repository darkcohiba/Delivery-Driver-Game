using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowSpeed = 10f;
    //float moveAmount;


    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
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
        moveSpeed = slowSpeed;    
    }
}
