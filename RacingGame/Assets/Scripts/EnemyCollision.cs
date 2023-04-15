using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

  private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag == "Player") 
      {
      //Get the contact point and normals
      ContactPoint contact = collision.contacts[0];
      Vector3 normal = contact.normal;
      
      //Calculate the reflection vector
      Vector3 reflection = Vector3.Reflect(transform.forward, normal);

      //Apply the reflection force to the colliding object
      Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
      rb.AddForce(reflection * 0.5f, ForceMode.Impulse);

      //Applies sound when colliding with the object
      source.PlayOneShot(clip);
    }
  }
}
