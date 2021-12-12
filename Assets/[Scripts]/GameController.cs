using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Spawn Point")]
    public Transform playerTransform;
    public Transform currentSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform.position = currentSpawnPoint.position;
    }

    public void setCurrentSpawnPoint(Transform newSpawnPoint)
    {
        currentSpawnPoint = newSpawnPoint;
    }
}
