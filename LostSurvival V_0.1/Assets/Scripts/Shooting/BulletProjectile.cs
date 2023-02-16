using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] private int BullitDamage = 10;
    private Rigidbody bulletRigidbody;
    PhotonView _pv;

    public GameObject shotBy;

    public void setShotBy(GameObject s) { shotBy = s; }

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
        _pv = GetComponent<PhotonView>();
    }


    public void setBullitDamage(int damage)
    {
        this.BullitDamage = damage;
    }

    private void Start() {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (! _pv.IsMine)
            return;

        if (other.GetComponent<DamageAble>() != null) {
          
            // Hit target
            PhotonNetwork.Instantiate(vfxHitGreen.name, transform.position, Quaternion.identity);
            // GiveDamage
            other.GetComponent<DamageAble>()?.giveDamage(BullitDamage);
            other.GetComponent<DamageAble>()?.setShotBy(shotBy);
        }

        else if (other.GetComponent<PlayerHealth>() != null)
        {
       
            // Hit target
            PhotonNetwork.Instantiate(vfxHitGreen.name, transform.position, Quaternion.identity);
            // GiveDamage
            other.GetComponent<PlayerHealth>()?.GiveDamage(BullitDamage);
        }
        else{
       
            PhotonNetwork.Instantiate(vfxHitRed.name, transform.position, Quaternion.identity);
        }

        
        


        if (_pv.IsMine)
            PhotonNetwork.Destroy(this.gameObject);
    }

}