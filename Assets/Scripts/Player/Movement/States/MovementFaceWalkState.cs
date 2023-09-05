using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Player/PlayerMovementState/FaceWalk")]
public class MovementFaceWalkState : MovementWalkState
{
    [SerializeField] private float _animInterpolation;
    private Vector3 _preLocalDir = Vector3.zero;
    public override void OwnerUpdate()
    {
        Vector3 direction = new Vector3(_lastInputDir.x, 0, _lastInputDir.y);
        Vector3 localDir = _playerMovement.transform.InverseTransformVector(direction.normalized);
        

        localDir = Vector3.Lerp(_preLocalDir, localDir,_animInterpolation);
        _preLocalDir = localDir;
        _animator.SetFloat("Horizontal", localDir.x);
        _animator.SetFloat("Vertical", localDir.z);

        RotateToCursor();
        Move(direction, _playerMovement.Config.WalkSpeed);
        _lastInputDir = _playerMovement.Player.PlayerInput.Movement.Move.ReadValue<Vector2>();

    }

    public override void Input()
    {
        base.Input();
        if (!_playerMovement.Player.PlayerInput.Movement.Move.IsPressed() || !_playerMovement.Player.PlayerInput.Combat.Aim.IsPressed())
        {
            _animator.SetBool("FaceWalk", false);
        }
    }

}
