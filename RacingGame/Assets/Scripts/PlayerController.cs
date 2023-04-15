using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  Rigidbody rb;
  [SerializeField] float movementSpeed = 6f;
    void Start()
    {
      rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
      //Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
    }

    //Checks Collision with the Enemy Car
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("You've hit the enemy car.");
            rb.AddForce(collision.contacts[0].normal * 20f, ForceMode.Impulse);
        }
    }
}