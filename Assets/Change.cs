using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Change : NetworkBehaviour
{
    public MovementNET movementNET;
    public GameObject tile;

    public void CHange()
    {
        movementNET = GameObject.Find("Player (1) [connId=0]").GetComponent<MovementNET>();
        movementNET.tile = tile;
    }
}
