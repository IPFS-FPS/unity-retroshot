using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GenerateCubes : MonoBehaviourPun
{
  // Start is called before the first frame update
  void Start()
  {
    if (!PhotonNetwork.IsMasterClient) return;

    Generate("PinkCube");
    Generate("PurpleCube");
    Generate("PinkBlueCube");
  }

  void Generate(string prefabName)
  {
    for (int i = 0; i < 50; i++)
    {
      float randomX = Random.Range(1, 50);
      float randomY = Random.Range(1, 200);
      float randomZ = Random.Range(1, 50);

      int maxScaleRange = 5;
      float randomXScale = Random.Range(1, 10);
      float randomYScale = Random.Range(1, 10);
      float randomZScale = Random.Range(1, 10);

      GameObject cube = PhotonNetwork.InstantiateSceneObject(prefabName, new Vector3(randomX, randomY, randomZ), Quaternion.identity);

      Vector3 scaleChange = new Vector3(randomXScale, randomYScale, randomZScale);
      cube.transform.localScale += scaleChange;
    }
  }

}
