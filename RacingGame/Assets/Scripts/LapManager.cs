using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
  public List<Checkpoint> checkpoints;
  public int totalLaps;

  private void OnTriggerEnter(Collider collision)
  {
    if(collision.gameObject.GetComponent<PlayerController>())
    {
      PlayerController player = collision.gameObject.GetComponent<PlayerController>();
      if(player.checkpointIndex == checkpoints.Count)
      {
        player.checkpointIndex = 0;
        player.lapNumber++;

        Debug.Log("You are now on lap " + player.lapNumber + "/" + totalLaps);

        if(player.lapNumber > totalLaps)
        {
          Debug.Log("You Won!");
          SceneManager.LoadScene(2);

        }
      }
    }
  }
}
