using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
  [SerializeField, Tooltip("Orient the rotation of the object to the forward" +
    "vector of the next waypoint")]
  private bool orientRotationToWaypoint = true;
  private Waypoint nextWaypoint = null;

  public delegate void OnCompletePath();
  public OnCompletePath OnPathCompleted;

  public delegate void OnReachWaypoint();
  public OnCompletePath WaypointReached;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetNextWaypoint(Waypoint waypoint)
  {
    nextWaypoint = waypoint;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject == nextWaypoint.gameObject)
    {
      Debug.Log("<color='cyan'>Waypoint reached</color>");
      // Waypoint reached!
      if (nextWaypoint.Next != null)
      {
        transform.position = new Vector3(nextWaypoint.transform.position.x, 
          transform.position.y, nextWaypoint.transform.position.z);

        if (orientRotationToWaypoint)
        {
          transform.rotation = nextWaypoint.transform.rotation;
        }

        nextWaypoint = nextWaypoint.Next;

        if (WaypointReached != null)
        {
          WaypointReached();
        }

      } else
      {
        OnPathCompleted();
      }
    }
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;

    if (nextWaypoint != null)
    {
      Gizmos.DrawSphere(nextWaypoint.transform.position, 1.0f);
    }
  }
}
