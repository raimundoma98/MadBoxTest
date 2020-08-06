using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  public Vector3 Direction { get { return transform.forward; } }
  [SerializeField]
  private Waypoint prev = null;
  public Waypoint Prev { get { return prev; } }
  [SerializeField]
  private Waypoint next = null;
  public Waypoint Next { get { return next; } }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
  }
}
