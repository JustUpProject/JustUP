using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_floor : MonoBehaviour
{
    BasicControler player;
    public LayerMask layerMask;
    Vector2 thisPos;
    Vector2 playerPos;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        player = FindObjectOfType<BasicControler>();
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
        if (playerPos.y > thisPos.y+0.05f)
        {
            transform.gameObject.tag = "Object";
            boxCollider2D.enabled = true;
        }
        else if (playerPos.y < thisPos.y)
        {
            transform.gameObject.tag = "Untagged";
            boxCollider2D.enabled = false;
        }
    }
}
