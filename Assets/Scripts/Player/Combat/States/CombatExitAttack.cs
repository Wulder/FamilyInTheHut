using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Player/PlayerCombatState/ExitAttack")]
public class CombatExitAttack : CombatState
{
    public override void OwnerExit()
    {
        base.OwnerExit();
        _animator.SetBool("Attack", false);
    }
}
