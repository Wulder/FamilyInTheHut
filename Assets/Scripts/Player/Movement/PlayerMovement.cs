using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(Player))]
public class PlayerMovement : NetworkBehaviour
{
    
    [SerializeField] private NetworkAnimator _netAnimator;
    [SerializeField] private CharacterController _cc;
    [SerializeField] private PlayerMovementConfig _config;

    private Player _player;
    private MovementState _currentState;
    public Player Player => _player;
    public CharacterController CC => _cc;
    public PlayerMovementConfig Config => _config;
    public MovementState CurrentState => _currentState;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    public override void OnStartClient()
    {
        base.OnStartClient();
        foreach (PlayerMovementStateBehaviour behaviour in _netAnimator.animator.GetBehaviours<PlayerMovementStateBehaviour>())
        {
            behaviour.Init(this);
        }
    }

    private void FixedUpdate()
    {
        if(isOwned)
        {
            AppendGravity();
        }
    }
    public void ChangeState(MovementState state)
    {
        _currentState = state;
    }

    void AppendGravity()
    {
        _cc.SimpleMove(Vector3.down * _config.GravityScale);
    }

}
