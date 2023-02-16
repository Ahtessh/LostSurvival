using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class DeactivateCameras : MonoBehaviour
{
    PhotonView pv; // Start is called before the first frame update
    void Start()
    {

        pv = GetComponentInParent<PhotonView>();
        if (!pv.IsMine)
        {
            gameObject.SetActive(false);
        }

    }

}
