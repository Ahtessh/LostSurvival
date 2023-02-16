using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using Photon.Pun;

public class ThirdPersonShooterController : MonoBehaviour {

    [SerializeField] private PickUpSlotManager slotMan;
    [SerializeField] private Rig rig;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;

    [SerializeField] private bool canShoot;
    [SerializeField] private  bool isAiming;
    //[SerializeField] private Transform vfxHitGreen;
    // [SerializeField] private Transform vfxHitRed;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private float aimRigweight;
    private void Awake() {
        canShoot = false;
        isAiming = false;
        slotMan = GetComponent<PickUpSlotManager>();    
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Update() {

        string _currentweapon = slotMan.getCurrentWeapon();

        if (_currentweapon.Equals("gun") || _currentweapon.Equals("pistol"))
            canShoot = true;
        else
            canShoot = false;
        
        if (!canShoot)
        {
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
            aimRigweight = 0f;
            rig.weight = Mathf.Lerp(rig.weight, aimRigweight, Time.deltaTime * 20f);
            return; 
        }
        else
        {
            Vector3 mouseWorldPosition = Vector3.zero;
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            Transform hitTransform = null;
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            {
                debugTransform.position = raycastHit.point;
                mouseWorldPosition = raycastHit.point;
                hitTransform = raycastHit.transform;
            }

            if (starterAssetsInputs.aim)
            {
                isAiming = true;
                aimRigweight = 1f;
                rig.weight = Mathf.Lerp(rig.weight, aimRigweight, Time.deltaTime * 20f);
                aimVirtualCamera.gameObject.SetActive(true);
                thirdPersonController.SetSensitivity(aimSensitivity);
                thirdPersonController.SetRotateOnMove(false);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));

                Vector3 worldAimTarget = mouseWorldPosition;
                worldAimTarget.y = transform.position.y;
                Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

                transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            }
            else
            {
                isAiming = false;
                aimRigweight = 0f;
                rig.weight = Mathf.Lerp(rig.weight, aimRigweight, Time.deltaTime * 20f);
                aimVirtualCamera.gameObject.SetActive(false);
                thirdPersonController.SetSensitivity(normalSensitivity);
                thirdPersonController.SetRotateOnMove(true);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
            }

            if (starterAssetsInputs.shoot && isAiming) 
            {
               
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                PhotonNetwork.Instantiate(pfBulletProjectile.name, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                //Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.shoot = false;
            }

            /*if (starterAssetsInputs.shoot)
            {
                //*
                // Hit Scan Shoot
                if (hitTransform != null)
                {
                    // Hit something
                    if (hitTransform.GetComponent<BulletTarget>() != null)
                    {
                        // Hit target
                        Instantiate(vfxHitGreen, mouseWorldPosition, Quaternion.identity);
                    }
                    else
                    {
                        // Hit something else
                        Instantiate(vfxHitRed, mouseWorldPosition, Quaternion.identity);
                    }
                }
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.shoot = false;
            }*/

        }      
    }

}