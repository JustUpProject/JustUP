using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class object_floor : MonoBehaviour
{
    public GameObject player;
    public LayerMask layerMask;
    Vector2 thisPos;
    Vector2 playerPos;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        playerPos = player.transform.position;
        thisPos = transform.position;
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }

    void Update()
    {
        playerPos = player.transform.position;
        thisPos = transform.position;
        checkPlayerPos(playerPos);
    }


    private void checkPlayerPos(Vector2 playerPos)
    {
        if (playerPos.y > thisPos.y)
        {
            transform.gameObject.tag = "Floor";
            boxCollider2D.enabled = true;
        }
        else if (playerPos.y < thisPos.y)
        {
            transform.gameObject.tag = "Untagged";
            boxCollider2D.enabled = false;
        }
    }
}
