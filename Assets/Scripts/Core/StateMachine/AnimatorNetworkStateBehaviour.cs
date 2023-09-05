using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEditor;


public class AnimatorNetworkStateBehaviour<T> : StateMachineBehaviour where T : State
{
    
    private protected NetworkIdentity _netIdentity;

    [SerializeField] private protected T _state;

    private protected T _stateInstance;

   

    #region Base
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_netIdentity || !_state) return;
 
        if (_netIdentity.isServer)
            _stateInstance.ServerEnter();

        if (_netIdentity.isOwned)
            _stateInstance.OwnerEnter(animator);

        _stateInstance.LocalEnter();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_netIdentity || !_state) return;

        if (_netIdentity.isServer)
            _stateInstance.ServerUpdate();

        if (_netIdentity.isOwned)
        {
            _stateInstance.OwnerUpdate();
            _stateInstance.Input();
        }

        _stateInstance.LocalUpdate();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_netIdentity || !_state) return;

        if (_netIdentity.isServer)
            _stateInstance.ServerExit();

        if (_netIdentity.isOwned)
            _stateInstance.OwnerExit();

        _stateInstance.LocalExit();
    }



    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
    #endregion;


    protected virtual void CreateStateInstance()
    {
        _stateInstance = Instantiate(_state);
    }
}
