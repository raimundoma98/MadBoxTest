using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownState : GameState
{
  public Text CountDownText;

  [SerializeField]
  private float duration;
  private float timer = 0.0f;

  CountdownState()
  {
    Type = EGameState.GS_CountDown;
  }

  CountdownState(float countdownDuration)
  {
    duration = countdownDuration;
  }

  public override void init()
  {
    CountDownText.enabled = false;
  }

  public override void start() {
    CountDownText.enabled = true;
    timer = 0.0f;
    ++duration;
    GetComponent<GameManager>().Player.GetComponent<InputForwardMovement>().enabled = false;
  }

  public override void update()
  {
    timer += Time.deltaTime;
    int remainingSeconds = Mathf.FloorToInt(duration - timer);
    CountDownText.text = (remainingSeconds > 0) ? remainingSeconds.ToString() : "Go!";

    if (timer >= duration)
    {
      finish();
    }
  }

  public override void finish()
  {
    timer = 0.0f;
    CountDownText.enabled = false;

    if (OnFinish != null)
    {
      OnFinish();
    }
  }
}
