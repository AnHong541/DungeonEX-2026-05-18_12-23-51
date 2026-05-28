using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawnPoint : MonoBehaviour
{
    [Header("Spawn Point")]
    public Transform spawnPoint;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
        }
    }
}