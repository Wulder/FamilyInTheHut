using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamLobby : MonoBehaviour
{
    private Callback<LobbyCreated_t> _lobbyCreatedCallback;
    private Callback<GameLobbyJoinRequested_t> _gameLobbyJoinRequestedCallback;

    private CSteamID _lobbyCSteamID;

    private string _hostAddress;

    private const string HOST_ADDRESS = "host_address";
    void Start()
    {
        Create();
        _lobbyCreatedCallback = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        _gameLobbyJoinRequestedCallback = Callback<GameLobbyJoinRequested_t>.Create(OnGameLobbyJoinRequested);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Create()
    {
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, 4);
        _hostAddress = SteamUser.GetSteamID().m_SteamID.ToString();
        Debug.Log(_hostAddress);
    }

    #region Callbacks

    private void OnLobbyCreated(LobbyCreated_t callback)
    {
        if (callback.m_eResult != EResult.k_EResultOK)
        {
            Debug.LogWarning($"Can't create lobby ({callback.m_eResult})");
        }
        else
        {
            Debug.Log("Lobby has been created.");

            //CustomNetworkManager.Instance.StartHost();

            _lobbyCSteamID = new CSteamID(callback.m_ulSteamIDLobby);
            _hostAddress = SteamUser.GetSteamID().m_SteamID.ToString();

            SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), HOST_ADDRESS, _hostAddress.ToString());


        }

    }
    private void OnGameLobbyJoinRequested(GameLobbyJoinRequested_t callback)
    {
        _lobbyCSteamID = callback.m_steamIDLobby;
        SteamMatchmaking.JoinLobby(_lobbyCSteamID);

        StartCoroutine(nameof(JoinGame));

    }

    #endregion

    IEnumerator JoinGame()
    {
        yield return new WaitForSeconds(1);
        _hostAddress = SteamMatchmaking.GetLobbyData(_lobbyCSteamID, HOST_ADDRESS);

        Debug.Log(_hostAddress);
        CustomNetworkManager.Instance.networkAddress = _hostAddress.ToString();
        CustomNetworkManager.Instance.StartClient();
        yield return null;
    }
}
