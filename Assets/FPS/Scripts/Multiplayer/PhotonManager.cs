using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonManager : MonoBehaviourPun
{
  [SerializeField]
  GameObject[] SpawnPoints;

  // Start is called before the first frame update
  void Start()
  {
    print("Instantiating player");
    int randomSpawnIndex = Random.Range(0, SpawnPoints.Length);
    PhotonNetwork.Instantiate("Player", SpawnPoints[randomSpawnIndex].transform.position, SpawnPoints[randomSpawnIndex].transform.rotation, 0);
  }

}
