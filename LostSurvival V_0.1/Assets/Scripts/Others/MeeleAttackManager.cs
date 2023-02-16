using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttackManager : MonoBehaviour
{

    private StarterAssetsInputs starterinput;
    public PickUpSlotManager pickslotmanager;
    public bool isStabbing;
    private Animator anim;
    private bool canStab;
    void Awake()
    {
        isStabbing = false;
        canStab = false;
        starterinput = GetComponent<StarterAssetsInputs>();
        anim = GetComponent<Animator>();
        pickslotmanager = gameObject.GetComponent<PickUpSlotManager>();
    }

    void Update()
    {
        if (canStab)
        {
            if (starterinput.stab)
            {
                isStabbing = true;
                anim.SetTrigger("Stab");
                starterinput.resetAttack(false);
                StartCoroutine(resetAttackDuration());

            }
        }
      
       
        
    }
    IEnumerator resetAttackDuration()
    {
        yield return new WaitForSeconds(1);
        isStabbing = false;
    }

    public bool checkStabbingStatus()
    {
        return isStabbing;
    }

    public void setCanStab(bool newState)
    {
        canStab = newState;
    }

    public bool checkState()
    {
        return canStab;
    }
}
