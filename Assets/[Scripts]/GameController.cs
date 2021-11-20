using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Spawn Point for Player
    public Transform player;
    public Transform playerSpawnPoint;

    private void Start()
    {
        player.position = playerSpawnPoint.position;
    }
    
}
