using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class DamageAble : MonoBehaviour
{

   [SerializeField]  private int health = 100;
    [SerializeField] private PhotonView pv;
    public Slider slider;
    public int heal_point = 10;
    public GameObject shotBy;
    public bool Healed=false;
    public void setShotBy(GameObject newGameObject)
    {
        shotBy = newGameObject;
    }
    private void Start()
    {
        slider.maxValue = health;
        heal_point = 10;
        pv = GetComponent<PhotonView>();    
    }
    // public bool doIt=false;
    void Update()
    {

       // slider.value = health;
     //   if (!pv.IsMine) return;
        if (health <= 0)
        {

            if (shotBy != null && Healed == false)
            {
                Healed = true;
                GameObject.FindGameObjectWithTag(shotBy.tag).GetComponent<PlayerHealth>().getHeal(heal_point);
            }

            if (gameObject.GetComponent<PhotonView>().IsMine == true && PhotonNetwork.IsConnected == true)
            {
                PhotonNetwork.Destroy(gameObject);
            }


        }
    }

    public void giveDamage(int damage)
    {
        if (health <= 0)
        {
            return;
        }
       
        pv.RPC("updateFill",RpcTarget.All,damage);
    }

    
    [PunRPC]
    void updateFill(int damage)
    {
        health -= damage;
        slider.value = health;
    }
}
