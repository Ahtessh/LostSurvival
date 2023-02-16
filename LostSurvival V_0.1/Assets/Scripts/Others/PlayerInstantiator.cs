using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PlayerInstantiator : MonoBehaviour
{


    PhotonView PV;
/*
    bool spawnPoint1 = true;
    bool spawnPoint2 = true;*/

    public GameObject player1;
    public GameObject player2;
    public Transform sp1;
    public Transform sp2;


    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Start()
    {
        if (PV.IsMine)
        {
            Spawn(player1.name, sp1);
        }
        if (!PV.IsMine)
        {
            Spawn(player2.name, sp2);

        }
        /*SpawnMasterPlayer();

        SpawnPlayer2();
*/
    }
    /*private void SpawnMasterPlayer()
    {
        
    }

    private void SpawnPlayer2()
    {
       
    }*/

   /* private int CheckPlayers()
    {
        return PhotonNetwork.CurrentRoom.PlayerCount;

    }*/

   

    void Spawn(string name, Transform sp)
    {
        PhotonNetwork.Instantiate(name, sp.position, Quaternion.identity);
    }

   
}
