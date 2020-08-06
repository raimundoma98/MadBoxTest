using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField]
  private Track track;
  [SerializeField]
  private GameObject playerPrefab;
  public GameObject Player { get; private set; }

  [SerializeField]
  public List<GameState> states;
  private int currentStateIndex = 0;
  private bool isPlayerDying = false;

  // Start is called before the first frame update
  void Start()
  {
    currentStateIndex = 0;
    Player = Instantiate(playerPrefab, track.StartWaypoint.transform.position,
      Quaternion.identity);

    Player.GetComponent<ObstacleCollision>().OnObstacleCollision += playerCollidesWithObstacle;

    foreach (GameState state in states)
    {
      state.OnFinish += onFinishCurrentState;
    }

    initGame();
  }

  // Update is called once per frame
  void Update()
  {
    states[currentStateIndex].update();
  }

  private void onPlayerReachesGoal()
  {
    Debug.Log("<color='green'>Player Wins!</color>");
    Player.GetComponent<InputForwardMovement>().enabled = false;
  }

  private void onFinishCurrentState()
  {
    ++currentStateIndex;
    states[currentStateIndex].start();
  }

  private void playerCollidesWithObstacle(GameObject collided, GameObject obstacle)
  {
    if (!isPlayerDying)
    {
      isPlayerDying = true;
      StartCoroutine(PlayerDiesCoroutine(2.0f));
      Debug.Log("Start player dies coroutine");
    }
  }

  private void initGame()
  {
    PathFollowing playerPathFollowing = Player.GetComponent<PathFollowing>();
    playerPathFollowing.SetNextWaypoint(track.StartWaypoint);
    playerPathFollowing.OnPathCompleted += onPlayerReachesGoal;
    Player.transform.position = track.StartWaypoint.transform.position;
    Player.transform.rotation = track.StartWaypoint.transform.rotation;

    Camera.main.GetComponent<FollowingCamera>().Target = Player.transform;

    foreach (GameState state in states)
    {
      state.init();
    }

    states[currentStateIndex].start();
  }

  public void resetGame()
  {
    if (states[currentStateIndex].Type == EGameState.GS_GameOver)
    {
      states[currentStateIndex].finish();
      currentStateIndex = states.FindIndex(s => s.Type == EGameState.GS_InGame);
    }

    initGame();
  }

  public void restartGame()
  {
    initGame();
  }

  IEnumerator PlayerDiesCoroutine(float duration)
  {
    yield return new WaitForSeconds(duration);

    Player.GetComponent<Rigidbody>().useGravity = false;
    Player.GetComponent<Rigidbody>().freezeRotation = true;
    Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    Player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    PathFollowing playerPathFollowing = Player.GetComponent<PathFollowing>();
    playerPathFollowing.SetNextWaypoint(track.StartWaypoint);
    Player.transform.position = track.StartWaypoint.transform.position;
    Player.transform.rotation = track.StartWaypoint.transform.rotation;
    isPlayerDying = false;
  }
}
