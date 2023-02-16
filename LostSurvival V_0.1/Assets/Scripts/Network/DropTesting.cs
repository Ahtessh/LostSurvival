using Photon.Pun;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTesting : MonoBehaviour
{
    public GameObject currentWeapon;
    [SerializeField]private GameObject player;
    public PickUpSlotManager slotManager;
    [SerializeField] private StarterAssetsInputs input;
    [SerializeField] private PhotonView _pv;
    private void Start()
    {
    
        slotManager = player.GetComponent<PickUpSlotManager>();
        _pv = GetComponent<PhotonView>();
    }

    public void setCurrentWeapon(GameObject weap)
    {
        currentWeapon = weap;
    }

    private void Update()
    {

        if (input.dropWeapon && slotManager.isFull  && (currentWeapon!=null))
        {
            input.resetDrop(false);
            _pv.RPC("dropWeapon", RpcTarget.AllBuffered);
            _pv.RPC("ExampleRPC", RpcTarget.AllBuffered);
            _pv.RPC("DestroyObj", RpcTarget.AllBuffered);


        }
        else
        {
            input.resetDrop(false);

        }

    }


    [PunRPC]
    public void dropWeapon()
    {
        slotManager.setWeaponState("none");

        slotManager.isFull = false;

           
       
        transform.DetachChildren();
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Rigidbody>().AddForce(transform.up * 10f);
        currentWeapon.GetComponent<Rigidbody>().useGravity = true;

       

    }
    [PunRPC]
    private void DestroyObj()
    {
       PhotonNetwork.Destroy(currentWeapon);
    }

   

    [PunRPC]
    public void ExampleRPC()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
    }
}
