using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{
    protected private PlayerCombat _playerCombat;

    public void Init(PlayerCombat pc)
    {
        _playerCombat = pc;
    }

   
}
