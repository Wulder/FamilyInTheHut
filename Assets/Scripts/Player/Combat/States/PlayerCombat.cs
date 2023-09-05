using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCombat : NetworkBehaviour
{
    [SerializeField] private NetworkAnimator _netAnimator;
    [SerializeField] private List<Weapon> _weaponList = new List<Weapon>();
    private Player _player;
    private CombatState _currentState;
    private Weapon _weapon;



    public CombatState CurrentState => _currentState;
    public Player Player => _player;
    public NetworkAnimator NetANimator => _netAnimator;
    public Weapon Weapon => _weapon;
    public List<Weapon> Weapons => _weaponList;
    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        foreach (PlayerCombatStateBehaviour behaviour in _netAnimator.animator.GetBehaviours<PlayerCombatStateBehaviour>())
        {
            behaviour.Init(this);
        }
    }

    public void ChangeState(CombatState state)
    {
        _currentState = state;
    }
}
