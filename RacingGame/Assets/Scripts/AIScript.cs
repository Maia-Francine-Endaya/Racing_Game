using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
  public float speed = 5f;
  public float raycastDistance = 1f;
  public float avoidanceDistance = 2f;
  public LayerMask obstacleMask;

  private Vector3 direction;
  public bool avoidingObstacle = false;
  public float spherecastRadius;

  [SerializeField] GameObject[] waypoints;
  int currentWaypointIndex = 0;

  //Laps and checkpoints for lap system
  public int lapNumber;
  public int checkpointIndex;

  private void Start()
    {
      lapNumber = 1;
      checkpointIndex = 0;
    }

  private void Update()
  {
    //Casts an area to detect obstacles
    RaycastHit hit;

    //Using the raycast, the object detects if there is an obstacle in its path
    if(Physics.SphereCast(transform.position, spherecastRadius, direction, out hit, raycastDistance, obstacleMask))
    {
      //If the hit distance is less than the avoidance distance (i.e. too near for the object)
      if(hit.distance < avoidanceDistance)
      {
        //The object will calculate its new direction to avoid the obstacle
        Vector3 avoidanceDirection = Vector3.Cross(hit.normal, Vector3.up).normalized;
        avoidingObstacle = true;
        direction = avoidanceDirection;
      }
      else
      {
        //Calculate the new direction based on the hit point
        Vector3 reflectionDirection = Vector3.Reflect(direction, hit.normal);
        direction = reflectionDirection;
      }

    }
    else
    {
      //If there is no obstacle, the object will continue along its normal path
      avoidingObstacle = false;
    }

    //Moves the object towards the waypoints
    if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
          currentWaypointIndex++;
          if (currentWaypointIndex >= waypoints.Length)
          {
            currentWaypointIndex = 0;
          }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
  }
}
