using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemTurn : Basic_Item
{
    // Start is called before the first frame update
    BasicControler player;
    SpriteRenderer spriteRenderer;
    private bool isTurn = false;

    private void Awake()
    {
        player = FindObjectOfType<BasicControler>();
        spriteRenderer = FindObjectOfType<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(isTurn) 
            {
                useTurn();//추후 베이직아이템 변경시 수정
            }
        }
    }

    private void useTurn()
    {
        player.SetDir();
        if (player.getPrivateDir() == true)
        {
            player.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            player.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTurn = true;
        }
        spriteRenderer.enabled = false;
    }
}
