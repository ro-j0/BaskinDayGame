using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class level_Manager : MonoBehaviour
{
    public static level_Manager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;
    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        GameObject Player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = Player.transform;
    }
}
