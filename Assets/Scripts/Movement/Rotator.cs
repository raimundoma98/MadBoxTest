using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
  [SerializeField]
  private Vector3 axis;
  [SerializeField]
  private float speed;

  private Quaternion initialRotation;

  // Start is called before the first frame update
  void Start()
  {
    initialRotation = transform.rotation;
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(axis, speed * Time.deltaTime);

    for (int i = 0; i < transform.childCount; ++i)
    {
      transform.GetChild(i).transform.rotation = initialRotation;
      
    }
  }
}
