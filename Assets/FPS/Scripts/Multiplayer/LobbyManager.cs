using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Runtime.InteropServices;

public class LobbyManager : MonoBehaviourPunCallbacks
{
  public byte maxPlayers = 20;
  [DllImport("__Internal")]
  private static extern int GetRoomFromURL();
  public Button startButton;
  private int privateRoom = 0;
  private RoomOptions roomOptions;
  
  void Start()
  {
    print("starting lobby manager");
    PhotonNetwork.ConnectUsingSettings();
  }

  public override void OnConnectedToMaster()
  {
    print("connected to host: " + PhotonNetwork.CloudRegion);
    // PhotonNetwork.AutomaticallySyncScene = true;
    FindRoom();
  }

  public void FindRoom()
  {
    #if UNITY_WEBGL && !UNITY_EDITOR
      privateRoom = GetRoomFromURL();
    #endif

    if (privateRoom > 0) {
      print("joining private room: " + privateRoom);
      RoomOptions roomOptions = new RoomOptions()
      {
        IsVisible = false,
        IsOpen = true,
        MaxPlayers = maxPlayers 
      };
      PhotonNetwork.JoinOrCreateRoom(privateRoom.ToString(), roomOptions, null);
    }  else {
      print("joining random room");
      PhotonNetwork.JoinRandomRoom();
    }
  }

  public override void OnJoinRandomFailed(short returnCode, string message)
  {
    print("no existing room");
    MakeRoom();
  }

  void MakeRoom()
  {
    print("making room...");
    int randomRoomName = Random.Range(1, 5000);
    RoomOptions roomOptions = new RoomOptions()
      {
        IsVisible = true,
        IsOpen = true,
        MaxPlayers = maxPlayers 
      };
    PhotonNetwork.CreateRoom(randomRoomName.ToString(), roomOptions);
    print("room created: " + randomRoomName);
  }

  public override void OnJoinedRoom()
  {
    print("player joined room");
    startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Play";
    startButton.GetComponent<Button>().interactable = true;
  }

}
