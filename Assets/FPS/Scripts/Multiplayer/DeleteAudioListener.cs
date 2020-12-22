using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeleteAudioListener: MonoBehaviourPun
{
  // Start is called before the first frame update
  void Start()
  {
    // delete photon player controller
    if (!photonView.IsMine)
    {
      print("destroying audio listener");
      Destroy(GetComponent<AudioListener>());
    }
  }

}
