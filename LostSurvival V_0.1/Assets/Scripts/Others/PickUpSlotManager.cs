using Photon.Pun;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSlotManager : MonoBehaviour
{
    
    public bool isFull;
    //public MeeleAttackManager mAttack;
   // [SerializeField] private StarterAssetsInputs input;
    [SerializeField]private string currentWeapon;
    [SerializeField] private GameObject dropItem;
    [SerializeField] private PhotonView  _pv;
    public void setWeaponState(string newWeapon)
    {
        currentWeapon = newWeapon;
    }

    public string getCurrentWeapon()
    {
         return currentWeapon ;
    }

    void Start()
    {
        _pv = GetComponent<PhotonView>();   
        currentWeapon = "none";
        isFull = false;
     //   input =  GetComponent<StarterAssetsInputs>();  
    
    }
 /*   private void Update()
    {
        if (!_pv.IsMine) return;
        
       *//* if (isFull)
        {

            if (currentWeapon.Equals("knife"))
                mAttack.setCanStab(true);
            else
                mAttack.setCanStab(false);

        }*//*
    


    }*/

    public void setSlot(bool newState)
    {
        isFull = newState;
    }
    public bool getSlot()
    {
        return isFull;
    }

/*    public bool getStabbingstatus()
    {
        return mAttack.checkStabbingStatus();
    }*/
 
}
