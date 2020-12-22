using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GenerateJetpack : MonoBehaviour
{
  void Start()
  {
    if (!PhotonNetwork.IsMasterClient) return;
    for (int i = 0; i < 4; i++) {
      float randomX = Random.Range(1, 50);
      float randomY = Random.Range(50, 100);
      float randomZ = Random.Range(1, 50);
      GameObject jetpack = PhotonNetwork.InstantiateSceneObject("Pickup_Jetpack", new Vector3(randomX, randomY, randomZ), Quaternion.identity);
    }
  }


}
