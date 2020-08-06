using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
  [SerializeField]
  private Platform prev;
  [SerializeField]
  private Platform next;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SpawnPlatformAtEnd(Platform otherPlatform)
  {
    Vector3 end_position = transform.position +
      Vector3.right * transform.localScale.x * 0.5f +
      Vector3.forward * transform.localScale.z * 0.5f;

    Platform new_platform = Instantiate(otherPlatform, end_position, Quaternion.identity);
    next = new_platform;
    new_platform.prev = this;
  }
}
