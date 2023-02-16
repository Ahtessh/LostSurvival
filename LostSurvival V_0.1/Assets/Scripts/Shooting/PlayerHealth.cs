using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PhotonView pv;
    public temp winlose;

    public const int maxHealth = 100;
    public int CurrentHealth = maxHealth;
    private void Start()
    {
        
        winlose = GameObject.FindGameObjectWithTag("winlose").GetComponent<temp>();


        if(gameObject.tag.Equals("MalePlayer"))
        winlose.setName_1(pv.Owner.NickName);
        if (gameObject.tag.Equals("FemalePlayer"))
            winlose.setName_2(pv.Owner.NickName);
    }

    public void getHeal(int heal) {
        if (CurrentHealth >= 100)
        {
            return;
        }
        if (gameObject.GetComponent<PhotonView>().IsMine == true && PhotonNetwork.IsConnected == true)
            pv.RPC("RPC_getHeal", RpcTarget.All, heal);

    }

    [PunRPC]
    public void RPC_getHeal(int heal) 
    {
        CurrentHealth += heal;
        if (pv.name.ToString().Contains("MalePlayer2"))
            winlose.setHealth_1(CurrentHealth.ToString());

        if (pv.name.ToString().Contains("FemalePlayer2"))
            winlose.setHealth_2(CurrentHealth.ToString());
    }
    public void GiveDamage(int damage)
    {
        pv.RPC("RPC_giveDamage", RpcTarget.All,damage);
    }


    [PunRPC]
   public  void RPC_giveDamage(int damage)
    {
        if (CurrentHealth > 0)
            CurrentHealth -= damage;

        if (pv.name.ToString().Contains("MalePlayer2"))
            winlose.setHealth_1(CurrentHealth.ToString());

        if (pv.name.ToString().Contains("FemalePlayer2"))
            winlose.setHealth_2(CurrentHealth.ToString());
          
      
      



    }
    private void Update()
    {
        if (CurrentHealth <= 0)
            Die();
    }

    void Die()
    {
        print("here");

        if (pv.name.ToString().Contains("MalePlayer2") && pv.GetComponent<PlayerHealth>()?.CurrentHealth <= 0)
        {

           

            string str = "Game End \n Player 1: died";
            winlose.setResult(str);
            winlose.enableLowerUI();
            winlose.disableUpperUI();
            this.gameObject.GetComponent<AllDisabler>()?.DisableAll();
            if (gameObject.GetComponent<PhotonView>().IsMine == true && PhotonNetwork.IsConnected == true)
                PhotonNetwork.Destroy(pv);

        }
        if (pv.name.ToString().Contains("FemalePlayer2") && pv.GetComponent<PlayerHealth>()?.CurrentHealth <= 0)
        {

            string str = "Game End \n Player 2 :  died";
            winlose.setResult(str);
            winlose.enableLowerUI();
            winlose.disableUpperUI();
            this.gameObject.GetComponent<AllDisabler>()?.DisableAll();
            if (gameObject.GetComponent<PhotonView>().IsMine == true && PhotonNetwork.IsConnected == true)
                PhotonNetwork.Destroy(pv);
            
        }


    }

}
