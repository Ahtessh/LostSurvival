using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeStab : MonoBehaviour
{
    public int knifeDamage = 10;
    [Header("For refernce so it wont kill without attack")]
    [SerializeField]
    private PickUpSlotManager pm=null;


    public void getReference()
    {
        pm = GameObject.FindGameObjectWithTag("MalePlayer").gameObject.GetComponent<PickUpSlotManager>(); ;

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
          
               /* if (pm.getStabbingstatus())
                {*/
                    var damage = other.gameObject.GetComponent<DamageAble>();
                    if (damage != null)
                    {
                        damage.giveDamage(knifeDamage);
                    }
             //   }
       
        }
    }
}
