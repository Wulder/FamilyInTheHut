using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovementStateBehaviour : AnimatorNetworkStateBehaviour<MovementState>
{
    private protected PlayerMovement _playerMovement;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _playerMovement.ChangeState(_state);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_stateInstance.GetType() != _playerMovement.CurrentState.GetType()) return;
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
    public void Init(PlayerMovement pm)
    {
        _playerMovement = pm;
        _netIdentity = _playerMovement.netIdentity;
        CreateStateInstance();
    }

    protected override void CreateStateInstance()
    {
        _stateInstance = Instantiate(_state);
        _stateInstance.Init(_playerMovement);
    }
}
