using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
  GS_CountDown,
  GS_InGame,
  GS_GameOver
}

public abstract class GameState : MonoBehaviour
{
  public delegate void OnFinishState();
  public OnFinishState OnFinish;
  public EGameState Type { get; protected set; }

  public abstract void init();
  public abstract void start();
  public abstract void update();
  public abstract void finish();
}
