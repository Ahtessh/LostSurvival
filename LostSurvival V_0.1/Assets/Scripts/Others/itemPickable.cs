using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickable : MonoBehaviour
{

    public Transform itemPickup;
    private GameObject PickupPosition=null;
  //  public GameObject girl_text;
    public string gunType;
    //public NetworkPickupsManager npm;
    public PhotonView _pv;
    public PickUpSlotManager slots;

    public SphereCollider pickCollider;
    private void Start()
    {
        gunType = itemPickup.GetComponent<WeaponManager>().getWeaponType();
      //  npm = GetComponentInParent<NetworkPickupsManager>();
        _pv= GetComponent<PhotonView>();
        pickCollider = GetComponent<SphereCollider>();
    }

    /*    private void OnTriggerEnter(Collider other)
        {

            if(other.gameObject.tag == "FemalePlayer")
            {
                //showMsg();
            }

            if(other.gameObject.tag == "MalePlayer")
            {
                var slots = other.gameObject.GetComponent<PickUpSlotManager>();
                if (slots != null)
                {
                    if (!slots.getSlot())
                    {
                        slots.setSlot(true);
                        slots.setWeaponState(gunType);

                        if (gunType.Equals("gun"))
                        {
                            PickupPosition = GameObject.FindGameObjectWithTag("gunPickPoint");
                            itemPickup.SetParent(PickupPosition.transform);
                            itemPickup.localPosition = new Vector3(0.16f, 0.03f, -0.03f);
                            itemPickup.localRotation = Quaternion.Euler(new Vector3(1.8f, 82.85f, -90f));
                            itemPickup.localScale = Vector3.one;
                            npm.reSpawn();
                            Destroy(this.gameObject);
                        }
                        if (gunType.Equals("knife"))
                        {
                            PickupPosition = GameObject.FindGameObjectWithTag("KnifePickPoint");
                            itemPickup.SetParent(PickupPosition.transform);
                            itemPickup.localPosition = Vector3.zero;
                            itemPickup.localRotation = Quaternion.Euler(new Vector3(71f, 82f, 99f));
                            itemPickup.localScale = Vector3.one;
                            itemPickup.GetComponent<KnifeStab>().getReference();
                            npm.reSpawn();
                            Destroy(this.gameObject);
                        }


                    }
                }


            }
        }*/


    private void OnTriggerEnter(Collider other)
    {
        if (!(_pv.IsMine)) return;

        if (other.gameObject.tag == "FemalePlayer")
        {
            _pv.RPC("PickupWeapon", RpcTarget.AllBuffered);
        }

        if (other.gameObject.tag == "MalePlayer")
        {
            _pv.RPC("PickupWeapon", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    void PickupWeapon()
    {
        
        print("here_1");
        if (slots != null)
            {
                if (!slots.getSlot())
                {
                pickCollider.enabled = false;
                slots.setSlot(true);
                    slots.setWeaponState(gunType);

                    if (gunType.Equals("gun"))
                    {
                        print("here");
                        PickupPosition = GameObject.FindGameObjectWithTag("gunPickPoint");
                        itemPickup.SetParent(PickupPosition.transform);
                        itemPickup.localPosition = new Vector3(0.16f, 0.03f, -0.03f);
                        itemPickup.localRotation = Quaternion.Euler(new Vector3(1.8f, 82.85f, -90f));
                        itemPickup.localScale = Vector3.one;
                       // npm.reSpawn();
                        //Destroy(this.gameObject);
                    }
                    if (gunType.Equals("knife"))
                    {
                        PickupPosition = GameObject.FindGameObjectWithTag("KnifePickPoint");
                        itemPickup.SetParent(PickupPosition.transform);
                        itemPickup.localPosition = Vector3.zero;
                        itemPickup.localRotation = Quaternion.Euler(new Vector3(71f, 82f, 99f));
                        itemPickup.localScale = Vector3.one;
                        itemPickup.GetComponent<KnifeStab>().getReference();
                       // npm.reSpawn();
                       // Destroy(this.gameObject);
                    }


                }
            }


    }


    /*  private void OnTriggerExit(Collider other)
      {
          if (other.gameObject.tag == "FemalePlayer")
          {
              hideMsg();
          }
      }*/

    [PunRPC]
    void showMsg()
    {
      //  girl_text.SetActive(true);
    }

    [PunRPC]
    void hideMsg()
    {
       // girl_text.SetActive(false);
    }
}
