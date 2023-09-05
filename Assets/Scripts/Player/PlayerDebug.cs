using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    [SerializeField] private Player _player;

    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    void Start()
    {
        _player.TryGetComponent(out _playerMovement);
        _player.TryGetComponent(out _playerCombat);
    }


    private void OnGUI()
    {
        Rect position = new Rect(new Vector2(Screen.width * 0.75f, Screen.height - 300), Vector2.one * 300);
        if (_playerMovement)
            WriteLabel(ref position, $"Movement State: {_playerMovement.CurrentState?.GetType()}");
        if (_playerCombat)
            WriteLabel(ref position, $"Combat State: {_playerCombat.CurrentState?.GetType()}");
    }



    void WriteLabel(ref Rect pos, string text, int offset = 15)
    {
        pos.y += offset;
        GUI.Label(pos, text);
    }
}
