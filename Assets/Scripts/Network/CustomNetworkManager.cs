using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class CustomNetworkManager : NetworkManager
{
    private static CustomNetworkManager _instance;
    public static CustomNetworkManager Instance => _instance;

    [SerializeField] private NetworkIdentity _character;

    private void Awake()
    {
        if(!_instance)
        {
            _instance = this;
        }
        
    }
    

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {

        base.OnServerDisconnect(conn);
        
        
    }

   
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        if(PlayersManager.Instance.Players.Find(p => p.AuthData == conn.address))
        {
            base.OnServerAddPlayer(conn);
           PlayersManager.Instance.Players.Find(p => p.AuthData == conn.address).netIdentity.RemoveClientAuthority();
            PlayersManager.Instance.Players.Find(p => p.AuthData == conn.address).netIdentity.AssignClientAuthority(conn);
            
        }
        else
        {
            conn.authenticationData = conn.address;
            base.OnServerAddPlayer(conn);

            NetworkIdentity c = Instantiate(_character);
            
            NetworkServer.Spawn(c.gameObject, conn);
            
            c.AssignClientAuthority(conn);
            c.GetComponent<Player>().SetAuthData(conn.address);


        }  
    }
}
