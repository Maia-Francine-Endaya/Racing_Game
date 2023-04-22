using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
  public int index;

  void OnTriggerEnter(Collider collision) {
    if(collision.gameObject.GetComponent<PlayerController>()) {
      PlayerController player = collision.gameObject.GetComponent<PlayerController>();

      if(player.checkpointIndex == index - 1)
      {
        player.checkpointIndex = index;
      }
    }

    if(collision.gameObject.GetComponent<AIScript>()) {
      AIScript aiCar = collision.gameObject.GetComponent<AIScript>();

      if(aiCar.checkpointIndex == index - 1)
      {
        aiCar.checkpointIndex = index;
      }
    }
  }
}
