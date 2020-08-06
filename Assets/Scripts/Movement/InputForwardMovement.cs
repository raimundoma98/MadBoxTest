using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputForwardMovement : MonoBehaviour
{
  [SerializeField]
  private float speed;
  private Rigidbody rb;

  private float movementValue = 0.0f;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
#if UNITY_EDITOR || UNITY_STANDALONE
    KeyboardMovement();
#elif UNITY_ANDROID
        MobileMovement();
#endif
  }

  private void FixedUpdate()
  {
    //rb.AddForce(transform.forward * movementValue);
    rb.velocity = transform.forward * movementValue;
    //rb.MovePosition(transform.position + transform.forward * movementValue);
  }

  private void KeyboardMovement()
  {
    movementValue = Input.GetAxis("ForwardMovement") * speed * 
      Time.deltaTime;
  }

  private void MobileMovement()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);

      if (touch.phase != TouchPhase.Ended && 
        touch.phase != TouchPhase.Canceled)
      {
        movementValue = speed * Time.deltaTime;
      } else if (touch.phase == TouchPhase.Ended)
      {
        movementValue = 0.0f;
      }
    }
  }

  private void OnDisable()
  {
    movementValue = 0.0f;

    if (rb != null)
    {
      rb.velocity = Vector3.zero;
    }
  }
}
