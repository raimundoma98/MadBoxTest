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

  // Start is called before the first frame update
  void Start()
  {
    currentStateIndex = 0;
    Player = Instantiate(playerPrefab, track.StartWaypoint.transform.position,
      Quaternion.identity);

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
}
