using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Mirror;
using System;

public class PlayersManager : MonoBehaviour
{


    private static PlayersManager _instance;
    private List<Player> _players = new List<Player>();
    private Player _localPlayer;
    public List<Player> Players => _players;
    public Player LocalPlayer => _localPlayer;
    public static PlayersManager Instance => _instance;
    void Awake()
    {
        if (!_instance) _instance = this;
    }


    private void OnDisable()
    {
        _instance = null;
    }

    public void AddPlayer(Player p)
    {
        if (p.isOwned)
            _localPlayer = p;

        if (!_players.Contains(p))
        {
            _players.Add(p);
            
        }
    }

    public void RemovePlayer(Player p)
    {
        if(_players.Contains(p))
        {
            _players.Remove(p);
        }
    }

}
