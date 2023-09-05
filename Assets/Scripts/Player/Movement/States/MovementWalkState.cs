using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Player/PlayerMovementState/Walk")]
public class MovementWalkState : MovementIdleState
{

    protected private Vector2 _lastInputDir = Vector2.zero;


    public override void OwnerEnter(Animator animator)
    {
        base.OwnerEnter(animator);
        _lastInputDir = _playerMovement.Player.PlayerInput.Movement.Move.ReadValue<Vector2>();
    }
    public override void OwnerUpdate()
    {
        base.OwnerUpdate();

        Vector3 direction = new Vector3(_lastInputDir.x, 0, _lastInputDir.y);
        Rotate(direction, _playerMovement.Config.WalkRotationSpeed);
        Move(direction, _playerMovement.Config.WalkSpeed);
        _lastInputDir = _playerMovement.Player.PlayerInput.Movement.Move.ReadValue<Vector2>();

    }

    public override void Input()
    {
        base.Input();
        if(!_playerMovement.Player.PlayerInput.Movement.Move.IsPressed())
        {
            _animator.SetBool("Walk", false);
            return;
        }

        if (_playerMovement.Player.PlayerInput.Movement.Move.IsPressed() && _playerMovement.Player.PlayerInput.Movement.Sprint.IsPressed())
        {
            _animator.SetBool("Sprint", true);
        }
       

        if (_playerMovement.Player.PlayerInput.Combat.Aim.IsPressed())
        {
            _animator.SetBool("Sprint", false);
            _animator.SetBool("FaceWalk", true);
            
        }
       
    }


}
