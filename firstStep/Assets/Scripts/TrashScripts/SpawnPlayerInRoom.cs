using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerInRoom : MonoBehaviour
{
    private Transform spawnPoint;

    private Transform playerTranform;

    private void Start()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;

        spawnPoint = GetComponentInChildren<Transform>();
    }
}
