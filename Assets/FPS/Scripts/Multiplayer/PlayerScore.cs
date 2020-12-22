using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerScore : MonoBehaviourPun
{
  public static string userName;
  public static float highScore = 0f;
  private string[] adjective = { "Neon", "Glowing", "Midnight", "Retro", "Synthetic", "Miami", "Electric", "Vapor", "Blinding", "Flashing", "Ferocious", "Time", "Robo", "Night", "Cyber", "Multi", "Atomic", "Artificial", "Sonic"};
  private string[] noun = { "FloppyDisk", "Timetraveler", "Dreamland", "Windows95", "PowerGlove", "Palmtree", "Pewpew", "Cop", "Hax0r", "Nightowl", "Doc", "Nightrider", "Walkman", "VHS", "Vice", "DungeonMaster", "Synthesizer"};

  // Start is called before the first frame update
  void Start()
  {
    if (!photonView.IsMine) return;
    string randomAdjective = adjective[Random.Range(0, adjective.Length)];
    string randomNoun = noun[Random.Range(0, noun.Length)];
    userName = randomAdjective + randomNoun;
  }

  void Update()
  {
    if (!photonView.IsMine) return;
    float currentHeight = gameObject.GetComponent<Transform>().position.y;
    if (currentHeight > highScore)
    {
      highScore = currentHeight;
      PhotonNetwork.LocalPlayer.NickName = userName + "\n" + highScore;
    }
  }


}
