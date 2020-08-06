using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : GameState
{
  private GameObject player;

  InGameState()
  {
    Type = EGameState.GS_InGame;
  }

  public override void init()
  {

  }

  public override void start()
  {
    player = GetComponent<GameManager>().Player;
    player.GetComponent<InputForwardMovement>().enabled = true;
    player.GetComponent<PathFollowing>().OnPathCompleted += finish;
  }

  public override void update()
  {

  }

  public override void finish()
  {
    if (OnFinish != null)
    {
      OnFinish();
    }
  }
}
