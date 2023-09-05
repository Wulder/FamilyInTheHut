using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Player/PlayerCombatState/Idle")]
public class CombatIdleState : CombatState
{
    public override void LocalEnter()
    {
        base.LocalEnter();
        _animator.SetLayerWeight(_animator.GetLayerIndex("Combat"), 0);
    }
    public override void Input()
    {
        base.Input();
        if(_playerCombat.Player.PlayerInput.Combat.Aim.IsPressed())
        {
            _animator.SetBool("Aim", true);
        }

        if(_playerCombat.Player.PlayerInput.Combat.Attack.IsPressed())
        {
            _animator.SetBool("Attack", true);
        }
    }
}
