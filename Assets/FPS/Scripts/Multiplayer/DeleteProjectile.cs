using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeleteProjectile: MonoBehaviourPun
{
  public GameObject Projectile_Blaster;

  // Start is called before the first frame update
  void Start()
  {
    // delete photon player controller
    if (!photonView.IsMine)
    {
      Destroy(Projectile_Blaster);
    }
  }

}
