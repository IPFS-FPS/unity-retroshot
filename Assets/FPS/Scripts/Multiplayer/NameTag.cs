using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NameTag : MonoBehaviourPun
{
  private PhotonView PV;
  private Text playerText;

  void Start()
  {
    PV = GetComponent<PhotonView>();
    playerText = GetComponent<Text>();
  }

  void Update()
  {
    playerText.text = PV.Owner.NickName;
  }

}
