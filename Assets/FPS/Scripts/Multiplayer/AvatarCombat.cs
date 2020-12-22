using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AvatarCombat : MonoBehaviour
{
  public int damage = 99;
  private PhotonView PV;
  public Transform rayOrigin;
  public Health health { get; private set; }

  // Start is called before the first frame update
  void Start()
  {
    PV = GetComponent<PhotonView>();
    health = GetComponent<Health>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!PV.IsMine) return;

    if (Input.GetMouseButtonDown(0))
    {
      PV.RPC("RPC_Shooting", RpcTarget.AllBuffered);
    }
  }

  [PunRPC]
  void RPC_Shooting()
  {
    RaycastHit hit;
    if (Physics.Raycast(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward), out hit, 1000))
    {
      Transform opponent = hit.transform;
      // if avatar and not me
      if (opponent.tag == "Avatar" && !PV.IsMine)
      {
        opponent.gameObject.GetComponent<Health>().TakeDamage(damage, opponent.gameObject);
      }

      if (opponent.tag == "Cube") {
        Vector3 rotateAmount = new Vector3(300, 300, 300);
        opponent.gameObject.transform.Rotate(rotateAmount * Time.deltaTime);
      }
    }
  }

}
