using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeletePlayer : MonoBehaviourPun
{
  public GameObject MainCameraObject;
  public GameObject WeaponCameraObject;
  // Start is called before the first frame update
  void Start()
  {
    DontDestroyOnLoad(gameObject);
    // delete photon player controller
    if (!photonView.IsMine)
    {
      print("destroying player");
      Destroy(GetComponent<PlayerCharacterController>());
      Destroy(GetComponent<Jetpack>());
      Destroy(GetComponent<Actor>());
      Destroy(GetComponent<Damageable>());
      Destroy(GetComponent<PlayerWeaponsManager>());
      Destroy(GetComponent<PlayerInputHandler>());

      Destroy(MainCameraObject.GetComponent<Camera>());
      Destroy(MainCameraObject.GetComponent<AudioListener>());

      Destroy(WeaponCameraObject.GetComponent<Camera>());
    }
  }

}
