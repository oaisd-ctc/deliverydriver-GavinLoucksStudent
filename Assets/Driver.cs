using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 8f;
    [SerializeField] float fastSpeed = 15f;

    [SerializeField] float driftSpeed = 600f;


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float forwardAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float drifty = Input.GetAxis("Jump") * driftSpeed * 2f * Time.deltaTime;
        transform.Rotate(0,0,-drifty);
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, forwardAmount, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp")
        {
            moveSpeed = fastSpeed;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
}
