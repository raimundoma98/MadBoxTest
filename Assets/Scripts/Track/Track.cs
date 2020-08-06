using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
  [SerializeField]
  private Waypoint startWaypoint;
  public Waypoint StartWaypoint { get { return startWaypoint; } }

  public float TrackLength { get; private set; }
  
  // Start is called before the first frame update
  void Start()
  {
    Waypoint current = startWaypoint;
    while (current.Next != null)
    {
      TrackLength += Vector3.Distance(current.transform.position,
        current.Next.transform.position);

      current = current.Next;
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
