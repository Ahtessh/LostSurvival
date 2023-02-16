using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

        int numberPlayers;
 
        bool spawnPoint1 = true;
        bool spawnPoint2 = true;

    public Transform sp1;
    public Transform sp2;

    private void Update()
        {
             if (numberPlayers == 1 && spawnPoint1 == true)
            {
                SpawnMasterPlayer();
                numberPlayers = 2;
                spawnPoint1 = false;
            }
            else if (numberPlayers == 2 && spawnPoint2 == true)
            {
                SpawnPlayer2();
                spawnPoint2 = false;
            }
            CheckPlayers();
        }
        
        private void SpawnMasterPlayer()
        {
           if(PV.IsMine)
        {
            CreateController("PhotonPrefabs",sp1);
        }
        }
 
        private void SpawnPlayer2()
        {
           
           Debug.Log("here");
               if(PV.IsMine)
        {
            CreateController("PhotonPrefabs2",sp2);
        }
        }
 
 
        void CheckPlayers()
        {
            numberPlayers = PhotonNetwork.CountOfPlayers;
            for (int i = 0; i <= numberPlayers; i++)
            {
                if (numberPlayers > 2)
                {
                    numberPlayers -= 2;
                }
            }
        }

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

   
    void CreateController(string name,Transform sp)
    {
       PhotonNetwork.Instantiate(Path.Combine(name,"PlayerController"), sp.position , sp.rotation , 0 , new object[] { PV.ViewID});
    }

    public void Die() // Respawn
    {
        //PhotonNetwork.Destroy(controller);

        // CreateController();
    }
}
