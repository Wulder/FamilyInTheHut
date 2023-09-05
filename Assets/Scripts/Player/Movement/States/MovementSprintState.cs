using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Player/PlayerMovementState/Sprint")]
public class MovementSprintState : MovementWalkState
{
    [SerializeField] private float _acceleration;
    private float _speed;

    public override void OwnerEnter(Animator animator)
    {
        base.OwnerEnter(animator);
        _speed = _playerMovement.Config.WalkSpeed;
    }
    public override void OwnerUpdate()
    {
      

        _speed = Mathf.Lerp(_speed, _playerMovement.Config.SprintSpeed, _acceleration);
        Vector2 _lastInputDir = _playerMovement.Player.PlayerInput.Movement.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(_lastInputDir.x, 0, _lastInputDir.y);
        Rotate(direction, _playerMovement.Config.SprintRotationSpeed);
        Move(direction, _speed);

    }


    public override void Input()
    {
        base.Input();
        if (!_playerMovement.Player.PlayerInput.Movement.Move.IsPressed() || !_playerMovement.Player.PlayerInput.Movement.Sprint.IsPressed())
        {
            _animator.SetBool("Sprint", false);
        }
    }

}
