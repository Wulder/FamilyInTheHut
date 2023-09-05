using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class Weapon : MonoBehaviour
{
    protected private NetworkIdentity _identity;
    protected private PlayerCombat _playerCombat;

    public PlayerCombat PlayerCombat => _playerCombat;
    public NetworkIdentity Identity => _identity;
}


public interface IStartAttack
{
    public void StartAttackEnter();
    public void StartAttackUpdate();
    public void StartAttackExit();
}

public interface IAttack
{

}

public interface IExitAttack
{

}