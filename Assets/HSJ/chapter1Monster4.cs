using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SpiderState
{
    MoveVirtical,
    MoveHorizontal,
    Stop
}

public class chapter1Monster4 : BasicMonster
{
    SpiderState spider;

    private BoxCollider2D colliderUP;
    private BoxCollider2D colliderDOWN;
    private BoxCollider2D colliderMonster;

    private Rigidbody2D spiderRig;

    private Vector2 targetPosition;

    private float timer;
    private int num = 0; // 1 = Up 0 = down

    private void Awake()
    {
        colliderMonster = GetComponent<BoxCollider2D>();

        colliderUP = gameObject.AddComponent<BoxCollider2D>();
        colliderDOWN = gameObject.AddComponent<BoxCollider2D>();

        spiderRig = FindObjectOfType<Rigidbody2D>();
    }

    private void Start()
    {
        colliderUP.size = new Vector2(0.2f, 4f);
        colliderUP.offset = new Vector2(0f, 9f);
        colliderUP.isTrigger = true;

        colliderDOWN.size = new Vector2(0.2f, 4f);
        colliderDOWN.offset = new Vector2(0f, -9f);
        colliderDOWN.isTrigger = true;

        colliderUP.enabled = false;
        colliderDOWN.enabled = false;
        targetPosition = Vector2.zero;
        timer = 4f;
    }


    protected override void Update()
    {
        timer -= Time.deltaTime;

        switch (spider)
        {
            case SpiderState.MoveHorizontal:
                if (timer < 0f)
                    base.Update();
                else
                {
                    setFloorChecker();
                    spider = SpiderState.Stop;
                    timer = 2f;
                }
                break;

            case SpiderState.Stop:
                if (colliderDOWN.enabled == false && colliderUP.enabled == false)
                {
                    colliderMonster.enabled = false;
                    spiderRig.gravityScale = 0f;
                    spider = SpiderState.MoveVirtical;
                    timer = 3f;
                }
                else
                {
                    if (timer < 0f)
                    {
                        colliderMonster.enabled = true;
                        spider = SpiderState.MoveHorizontal;
                        timer = 2f;
                    }
                }
                break;

            case SpiderState.MoveVirtical:
                if (timer < 0f)
                {
                    spiderRig.gravityScale = 1f;
                    colliderMonster.enabled = true;
                }
                if (gameObject.transform.position.y == targetPosition.y)
                {
                    spiderRig.gravityScale = 1f;
                    colliderMonster.enabled = true;
                }
                else
                    spiderRig.position = Vector2.MoveTowards(spiderRig.position, targetPosition, Time.deltaTime * 2);
                if (colliderMonster.enabled == true)
                {
                    spider = SpiderState.MoveHorizontal;
                    timer = 2f;
                }
                break;
        }
    }

    private void setFloorChecker()
    {
        num = Random.Range(0, 100);
        num = num % 2;

        if (num == 0)
        {
            colliderDOWN.enabled = true;
        }
        else
        {
            colliderUP.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            targetPosition = new Vector2(spiderRig.position.x, other.transform.position.y + (other.transform.localScale.y / 2) + (this.transform.localScale.y / 2));
            colliderUP.enabled = false;
            colliderDOWN.enabled = false;
        }
    }
}