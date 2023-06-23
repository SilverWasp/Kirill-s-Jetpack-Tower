using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 plaPos = new Vector3(0,0,-10);


    void Update()
    {
        plaPos.y = player.transform.position.y;
        transform.position = plaPos;
    }
}
