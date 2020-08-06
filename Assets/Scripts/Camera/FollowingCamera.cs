using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowingCamera : MonoBehaviour
{
  public Transform Target;
  [SerializeField, Tooltip("Offset from the target")]
  private Vector3 offset;
  [SerializeField]
  private float smoothSpeed;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Vector3 desiredPosition = Target.transform.position + 
      Target.transform.forward * offset.z + 
      Target.transform.up * offset.y;

    Vector3 direction = desiredPosition - transform.position;
    float distance = direction.magnitude;
    direction.Normalize();

    float movementValue = distance * smoothSpeed * Time.deltaTime;

    //transform.position += direction * movementValue;
    transform.position = Vector3.Lerp(transform.position, desiredPosition, 
      smoothSpeed);
    transform.LookAt(Target);
  }
}
