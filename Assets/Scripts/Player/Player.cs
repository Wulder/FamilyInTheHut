using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{


    [SerializeField] private List<GameObject> _disableObjects = new List<GameObject>();


    private PlayerInput _playerInput;

    private string _authData;
    public string AuthData => _authData;
    public PlayerInput PlayerInput => _playerInput;
    private void Awake()
    {
        
        _playerInput = new PlayerInput();
      

        foreach (GameObject g in _disableObjects)
            g.SetActive(false);

    }
    private void OnDisable()
    {
        _playerInput.Disable();
    }
    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        _playerInput.Enable();

        EnableObjects();
        PlayersManager.Instance.AddPlayer(this);

    }
    public override void OnStartClient()
    {
        
        base.OnStartClient();
        if (!isOwned)
        {
            _playerInput.Disable();
        }
        else
        {

            _playerInput.Enable();
            EnableObjects();
        }
        PlayersManager.Instance.AddPlayer(this);

    }
    void EnableObjects()
    {
        foreach (GameObject g in _disableObjects)
            g.SetActive(true);
    }
    public void SetAuthData(string data)
    {
        if (isServer)
            _authData = data;
    }

   
}
