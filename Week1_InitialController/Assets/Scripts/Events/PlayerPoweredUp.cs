using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoweredUp : GC.GameEvent {

    public readonly GameObject player;
    public PlayerPoweredUp(GameObject _player)
    {
        player = _player;
    }

}
