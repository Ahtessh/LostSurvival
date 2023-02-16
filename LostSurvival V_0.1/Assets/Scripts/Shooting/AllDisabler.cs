using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class AllDisabler : MonoBehaviour
{
    public ThirdPersonController s1;
    public NewThirdCntroller s2;
    public PlayerHealth s3;
    public PlayerInput s4;
    public RigBuilder s5;
    public GameObject cam1;
    public GameObject cam2;



    public void DisableAll()
    {
        s1.enabled = false;
        s2.enabled = false;
        s3.enabled = false;
        s4.enabled = false;
        s5.enabled = false;

        cam1.SetActive(false);
        cam2.SetActive(false);
    }
}
