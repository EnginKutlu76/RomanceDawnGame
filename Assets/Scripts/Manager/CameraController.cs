using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform room;
    public static CameraController instance;
    public Transform activeRoom;
    [Range(-5, 135)]
    public float minModX, maxModX, minModY, maxModY;
    public float dampSpeed = 3f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;
        Vector3 clampedPos = new Vector3(Mathf.Clamp(player.position.x, minPosX, maxPosX),
            Mathf.Clamp(player.position.y, minPosY, maxxPosY),
            Mathf.Clamp(player.position.z, -10, -10));

        Vector3 smoothPos = Vector3.Lerp(transform.position, clampedPos, dampSpeed * Time.deltaTime);

        transform.position = smoothPos;
    }
}