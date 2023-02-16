using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPickup : MonoBehaviour
{

    public PhotonView photonView;
   // public NetworkPickupsManager npm;
    public Transform itemPickup;
    public PickUpSlotManager slots;
    public string gunType;
    private void Start()
    {
        itemPickup = this.transform;
        gunType = itemPickup.GetComponent<WeaponManager>().getWeaponType();
    //    npm = GetComponentInParent<NetworkPickupsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.IsMine)
            return;
        
    /*    if (other.gameObject.GetComponent<PhotonView>().Owner.IsLocal)
        { //Are we the player that touch this object?
          */ 
            slots = other.gameObject.GetComponent<PickUpSlotManager>();

            if (slots != null)
            {
                if (!slots.getSlot())
                {
                    transform.GetComponent<SphereCollider>().enabled = false;
                    slots.setSlot(true);
                    slots.setWeaponState(gunType);
                    int targetPlayerID = photonView.ViewID; // reference to targetPlayer.
                    photonView.RPC("RPC_PlayerPickedUpWeapon", RpcTarget.AllBuffered, targetPlayerID);
                  //  npm.reSpawn();
                }
                else
                    return;
            }
            else
                return;


       // }
    }

    [PunRPC]
    private void RPC_PlayerPickedUpWeapon(int tarPly)
    {
        PhotonView tarPlyPV = PhotonView.Find(tarPly);
        if (tarPlyPV.gameObject != null && tarPlyPV.gameObject.tag.Equals("FemalePlayer2"))
        { //make sure player is active before proceeding
        
            GameObject PickupPosition = GameObject.FindGameObjectWithTag("gunPickPointf");
            PickupPosition.GetComponent<DropTesting>().setCurrentWeapon(itemPickup.gameObject);
            itemPickup.SetParent(PickupPosition.transform);
            itemPickup.localPosition = new Vector3(0.16f, 0.03f, -0.03f);
            itemPickup.localRotation = Quaternion.Euler(new Vector3(1.8f, 82.85f, -90f));
            itemPickup.localScale = Vector3.one;
           
        }
        if (tarPlyPV.gameObject != null && tarPlyPV.gameObject.tag.Equals("MalePlayer"))
        { //make sure player is active before proceeding

            GameObject PickupPosition = GameObject.FindGameObjectWithTag("gunPickPoint");
            PickupPosition.GetComponent<DropTesting>().setCurrentWeapon(itemPickup.gameObject);
            itemPickup.SetParent(PickupPosition.transform);
            itemPickup.localPosition = new Vector3(0.16f, 0.03f, -0.03f);
            itemPickup.localRotation = Quaternion.Euler(new Vector3(1.8f, 82.85f, -90f));
            itemPickup.localScale = Vector3.one;

        }
    }


}
