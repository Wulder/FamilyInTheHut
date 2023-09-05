using Mirror.Examples.Benchmark;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatStateBehaviour : AnimatorNetworkStateBehaviour<CombatState>
{
    protected private PlayerCombat _playerCombat;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _playerCombat.ChangeState(_state);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_stateInstance && _stateInstance.GetType() != _playerCombat.CurrentState.GetType()) return;
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
    public void Init(PlayerCombat pc)
    {
        _playerCombat = pc;
        _netIdentity = pc.netIdentity;
        CreateStateInstance();
    }

    protected override void CreateStateInstance()
    {
        _stateInstance = Instantiate(_state);
        _stateInstance.Init(_playerCombat);
    }
}
