using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class NetworkPickupsManager : MonoBehaviour
{

    public GameObject gun;
    public Transform[] spawnpoints;

    public PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Start()
    {

        for (int i = 0; i < spawnpoints.Length; i++)
        { Spawn(gun.name, spawnpoints[i]); }
        
            
     
     
    }
   
    void Spawn(string name, Transform sp)
    {
        PhotonNetwork.Instantiate(name, sp.position, Quaternion.identity);
    }

}
