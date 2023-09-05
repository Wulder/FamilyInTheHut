using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/State")]
public class State : ScriptableObject
{

    private protected Animator _animator;

    public virtual void ServerEnter() { }
    public virtual void ServerUpdate() { }
    public virtual void ServerExit() { }



    public virtual void OwnerEnter(Animator animator) { _animator = animator; }
    public virtual void OwnerUpdate() { }
    public virtual void OwnerExit() { }



    public virtual void LocalEnter() { }
    public virtual void LocalUpdate() { }
    public virtual void LocalExit() { }

    public virtual void Input() { }
}
