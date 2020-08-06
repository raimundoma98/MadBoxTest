using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
  public delegate void OnCollisionWithObstacle(GameObject collided, GameObject obstacle);
  public OnCollisionWithObstacle OnObstacleCollision;

  [SerializeField]
  private float impulseMultiplier;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Obstacle"))
    {
      OnObstacleCollision(gameObject, other.gameObject);
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Obstacle"))
    {
      gameObject.GetComponent<Rigidbody>().AddForce(collision.impulse * 
        impulseMultiplier);
      gameObject.GetComponent<Rigidbody>().useGravity = true;
      gameObject.GetComponent<Rigidbody>().freezeRotation = false;
      OnObstacleCollision(gameObject, collision.gameObject);
    }
  }
}
