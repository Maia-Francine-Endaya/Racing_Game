using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  Rigidbody rb;
  [SerializeField] float movementSpeed = 20f;

  //Laps and checkpoints for lap system
  public int lapNumber;
  public int checkpointIndex;

  //For speed boost
  private float boostTimer;
  private bool boosting;

  void Start()
    {
      rb = GetComponent<Rigidbody>(); 

      lapNumber = 1;
      checkpointIndex = 0;

      boostTimer = 0f;
      boosting = false;
    }

  
  void Update()
    {
      //Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetKey(KeyCode.Escape))
        {
          SceneManager.LoadScene(0);
        }

        //Checks how long the speed boost lasts
        if(boosting)
        {
          boostTimer += Time.deltaTime;
          if(boostTimer >= 1f)
          {
            boostTimer = 0f;
            boosting = false;
          }
        }
    }

    //Gives a speed boost when colliding with a booster
    void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Boost")
      {
        boosting = true;
        movementSpeed += 15;
      }
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

  //
}