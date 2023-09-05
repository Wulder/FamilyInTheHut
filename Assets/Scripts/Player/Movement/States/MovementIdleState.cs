using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Player/PlayerMovementState/Idle")]
public class MovementIdleState : MovementState
{


    public override void OwnerUpdate()
    {
        base.OwnerUpdate();
        if(_playerMovement.Player.PlayerInput.Combat.Aim.IsPressed())
        {
            RotateToCursor();
        }
            
    }

    public override void Input()
    {
        base.Input();
        if(_playerMovement.Player.PlayerInput.Movement.Move.IsPressed())
        {
            _animator.SetBool("Walk", true);
        }
        

        
    }
}
