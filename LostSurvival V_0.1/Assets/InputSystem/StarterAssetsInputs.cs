using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
        public bool gunShoot;
        public bool dropWeapon;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		[Header("Meele Attack Settings")]
		public bool stab=false;
        [Header("Shoot Attack Settings")]
        public bool aim;
        public bool shoot;


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
        public void OnGunShoot(InputValue value)
        {
           GunShootInput(value.isPressed);
        }
        public void OnStab(InputValue value)
        {
            StabInput(value.isPressed);
        }

        public void OnAim(InputValue value)
        {
            AimInput(value.isPressed);
        }

        public void OnShoot(InputValue value)
        {
            ShootInput(value.isPressed);
        }

        public void OnDropWeapon(InputValue value)
        {
            DropIWeaponInput(value.isPressed);
        }


#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
           
            move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
           
            jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
        public void GunShootInput(bool newSprintState)
        {
            gunShoot = newSprintState;
        }
        
        public void StabInput(bool newStabState)
        {
            stab = newStabState;
        }

        public void AimInput(bool newAimState)
        {
            aim = newAimState;
        }

        public void ShootInput(bool newShootState)
        {
            shoot = newShootState;
        }
        public void DropIWeaponInput(bool newDropState)
        {
            dropWeapon = newDropState;
        }
        

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			//Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		 public void resetAttack(bool newStarte)
		{
			stab = newStarte;
		}

        public void resetDrop(bool newStarte)
        {
            dropWeapon = newStarte;
        }

    }

}