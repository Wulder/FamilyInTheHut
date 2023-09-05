using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementState : State
{
    private protected PlayerMovement _playerMovement;

    public override void OwnerEnter(Animator animator)
    {
        base.OwnerEnter(animator);
    }

 
    public void Init(PlayerMovement pm)
    {
        _playerMovement = pm;
    }

    protected void Move(Vector3 dir, float speed)
    {
        _playerMovement.CC.Move(dir.normalized * speed * Time.fixedDeltaTime);
    }

    protected void Rotate(Vector3 dir, float interpolation)
    {
        if (dir != Vector3.zero)
        {
            Quaternion q = Quaternion.Lerp(_playerMovement.transform.rotation, Quaternion.LookRotation(dir), interpolation);

            _playerMovement.transform.rotation = q;
        }
    }

    protected void RotateToCursor()
    {
        Vector3 direction = Camera.main.WorldToScreenPoint(_playerMovement.transform.position + Vector3.up);
        Vector2 playerDir = new Vector2(direction.x, direction.y) - new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y);
        // float distToCursor = 1-Mathf.Clamp( new Vector2(playerDir.x, playerDir.y).magnitude/500,0.5f,1);  

        playerDir.Normalize();
        _playerMovement.transform.rotation = Quaternion.Lerp(_playerMovement.transform.rotation, Quaternion.LookRotation(new Vector3(-playerDir.x, 0, -playerDir.y)), _playerMovement.Config.ToCursorRotationSpeed);
    }
   
      


}
