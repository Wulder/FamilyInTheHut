using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/Player/PlayerCombatState/StartAttack")]
public class CombatStartAttackState : CombatState
{

    public override void OwnerEnter(Animator animator)
    {
        base.OwnerEnter(animator);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Combat"), 1);
    }

}
