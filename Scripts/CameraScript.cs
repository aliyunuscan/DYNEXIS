using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
           transform.position = new Vector3(player.position.x, player.position.y, -10);
        }
    }



}
