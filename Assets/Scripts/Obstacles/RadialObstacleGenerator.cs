using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialObstacleGenerator : MonoBehaviour
{
  [SerializeField]
  private GameObject obstaclePrefab;
  [SerializeField]
  private int totalObstacles;
  [SerializeField]
  private float radius;

  // Start is called before the first frame update
  void Start()
  {
    float angleOffset = 360.0f / totalObstacles;
    float angle = 0.0f;

    for (int i = 0; i < totalObstacles; ++i)
    {
      Vector3 pos;
      pos.x = transform.position.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
      pos.y = transform.position.y + obstaclePrefab.transform.localScale.y * 0.5f;
      pos.z = transform.position.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);

      GameObject new_obstacle = Instantiate(obstaclePrefab, pos, Quaternion.identity);
      new_obstacle.transform.SetParent(transform);

      angle += angleOffset;
    }
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  private void OnDrawGizmos()
  {
    float angleOffset = 360.0f / totalObstacles;
    float angle = 0.0f;

    for (int i = 0; i < totalObstacles; ++i)
    {
      Vector3 pos;
      pos.x = transform.position.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
      pos.y = transform.position.y + obstaclePrefab.transform.localScale.y * 0.5f;
      pos.z = transform.position.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);

      Gizmos.color = Color.blue;
      Gizmos.DrawMesh(obstaclePrefab.GetComponent<MeshFilter>().sharedMesh, pos, 
        Quaternion.identity, obstaclePrefab.transform.localScale);

      angle += angleOffset;
    }
  }
}
