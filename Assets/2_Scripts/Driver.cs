using System;
using Unity.VisualScripting;
using UnityEngine;
public class Driver : MonoBehaviour
{
    [SerializeField] float turnspeed = 180.0f;
    [SerializeField] float movespeed = 4.5f;
    [SerializeField] float slowSpeedRatid = 0.5f;
    [SerializeField] float boostSpeedRatid = 1.5f;
    float slowSpeed;
    float boostSpeed;
    void Start()
    {
        slowSpeed = movespeed * slowSpeedRatid;
        boostSpeed = movespeed * boostSpeedRatid;
    }
    void Update()
    {
        float turnamount = Input.GetAxis("Horizontal") * turnspeed * Time.deltaTime;
        float moveamount = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;
        transform.Rotate(0, 0, -turnamount);
        transform.Translate(0, moveamount, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            movespeed = boostSpeed;
            Debug.Log("Booooooost");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        movespeed = slowSpeed;
    }
}
