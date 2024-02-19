using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateBreakingBoard
{
    collide,
    breaking,
    recovery
}

public class object_breaking_board : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private StateBreakingBoard board;
    private bool isBroken;
    private float timer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        this.board = StateBreakingBoard.collide;
        isBroken = false;
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
        timer = 0f;
    }

    void Update()
    {
        switch (board)
        {
            case StateBreakingBoard.collide:
                if (timer >= 1f)
                {
                    spriteRenderer.enabled = false;
                    boxCollider2D.enabled = false;
                    board = StateBreakingBoard.breaking;
                }
                if (isBroken)
                    timer += Time.deltaTime;
                break;

            case StateBreakingBoard.breaking:
                if(timer >= 6f)
                    board = StateBreakingBoard.recovery;
                timer += Time.deltaTime;
                break;

            case StateBreakingBoard.recovery:
                spriteRenderer.enabled = true;
                boxCollider2D.enabled = true;
                isBroken = false;
                timer = 0f;
                board = StateBreakingBoard.collide;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isBroken = true;
        }
    }
}
