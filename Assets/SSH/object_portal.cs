using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class object_portal : MonoBehaviour
{
    BasicControler player;
    public GameObject otherPortal; // 다른 포탈
    public Transform portalPoint; // 포탈을 통해 이동할 위치
    public float teleportCooldown = 0f;

    bool teleportable = false;


    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
        teleportCooldown += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // 플레이어가 포탈에 접촉하면
        {
            if (teleportCooldown >= 1f)
            {
                teleportable = true;
                Teleport(collision.collider.gameObject); // 플레이어를 이동시킴                                               

            }

        }

    }

    private void Teleport(GameObject objectToTeleport)
    {
        if (teleportable)
        {
            objectToTeleport.transform.position = portalPoint.position;
            // 다른 포탈의 portalPoint로 이동시킴
            teleportCooldown = 0f;
            teleportable = false;
        }

    }

}