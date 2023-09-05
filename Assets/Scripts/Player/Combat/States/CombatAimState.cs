using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Player/PlayerCombatState/Aim")]
public class CombatAimState : CombatState
{

    public override void LocalEnter()
    {
        base.LocalEnter();
        _animator.SetLayerWeight(_animator.GetLayerIndex("Combat"), 1);
    }
    public override void Input()
    {
        base.Input();
        if(!_playerCombat.Player.PlayerInput.Combat.Aim.IsPressed())
        {
            _animator.SetBool("Aim", false);
        }
        if(_playerCombat.Player.PlayerInput.Combat.Attack.IsPressed())
        {
            _animator.SetBool("Attack", true);
        }
    }
}
