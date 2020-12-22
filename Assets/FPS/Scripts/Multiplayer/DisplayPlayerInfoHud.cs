using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerInfoHud : MonoBehaviour
{
  public Text playerScore;

  void Update()
  {
    playerScore.text = PlayerScore.userName + "\n" + PlayerScore.highScore;
  }

}
