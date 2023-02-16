using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerManagers : MonoBehaviour
{
   public PhotonView pv;
    public GameObject cam;
   
    void Start()
    {
        if(pv.IsMine)
        {
            cam.SetActive(true);
        }
    }

}
