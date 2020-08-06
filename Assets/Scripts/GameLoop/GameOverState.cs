using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState
{
  public Canvas GameOverCanvas;

  GameOverState()
  {
    Type = EGameState.GS_GameOver;
  }

  public override void init()
  {
    GameOverCanvas.enabled = false;
  }

  public override void start()
  {
    GameOverCanvas.enabled = true;
    GetComponent<GameManager>().Player.GetComponent<InputForwardMovement>().enabled = false;
  }

  public override void update()
  {

  }

  public override void finish()
  {
    GameOverCanvas.enabled = false;
  }
}
