using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Animations.Rigging;
using Cinemachine;
using StarterAssets;
using System.Reflection;
using UnityEngine.InputSystem.XR;

public class NewThirdCntroller : MonoBehaviour
{
    [SerializeField] private Rig rig;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera PlayerFollowVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private PhotonView _pv;
    [SerializeField] private static bool isAiming;
    public int BullitDamage;


    public bool onNetwork=false;
    public AudioSource audio;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private float aimRigweight;
    public bool debug = false;

    private void Start()
    {
        rig.weight = 0f;
        BullitDamage = 20;
        audio = GetComponent<AudioSource>();
        pfBulletProjectile.GetComponent<BulletProjectile>().setBullitDamage(BullitDamage);
    }

    private void Awake()
    {
       
        isAiming = false;
        _pv= GetComponent<PhotonView>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
     

        if (!_pv.IsMine) { return; }

            Vector3 mouseWorldPosition = Vector3.zero;
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
           // Transform hitTransform = null;
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            {
                debugTransform.position = raycastHit.point;
                mouseWorldPosition = raycastHit.point;
              //  hitTransform = raycastHit.transform;
            }

            if (starterAssetsInputs.aim || debug)
            {
                isAiming = true;
                aimRigweight = 1f;
                 rig.weight = aimRigweight;
            aimVirtualCamera.gameObject.SetActive(true);
                PlayerFollowVirtualCamera.gameObject.SetActive(false);
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
                 rig.weight =aimRigweight ;
                 aimVirtualCamera.gameObject.SetActive(false);
                PlayerFollowVirtualCamera.gameObject.SetActive(true);
                thirdPersonController.SetSensitivity(normalSensitivity);
                thirdPersonController.SetRotateOnMove(true);
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
            }

            if (starterAssetsInputs.shoot && isAiming)
            {

                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                  pfBulletProjectile.GetComponent<BulletProjectile>()?.setShotBy(gameObject);
             audio.Play();
            PhotonNetwork.Instantiate(pfBulletProjectile.name, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            //Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));

            starterAssetsInputs.shoot = false;
            }
      
    }
    

}
