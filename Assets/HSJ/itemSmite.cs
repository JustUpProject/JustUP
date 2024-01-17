using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSmite : Basic_Item
{
    private BasicControler player;
    private Rigidbody2D playerRig;

    [SerializeField] private float jumpPower = 2.5f;
    private bool usedSmite = false;

    private float flightTime = 0f;
    private float sturnTime = 0.5f;

    private void Awake()
    {
        player = FindObjectOfType<BasicControler>();
        playerRig = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        useSmite();
    }

    public void useSmite()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            jump();
        }

        flight();
        sturn();
    }

    private void jump()
    {
        playerRig.gravityScale = 1;
        playerRig.AddForce(transform.up*jumpPower, ForceMode2D.Impulse);
        usedSmite = true;
    }

    private void flight()
    {
        if(usedSmite) 
        {
            flightTime += Time.deltaTime;
        }
    }

    private void sturn() 
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 detecteArea = new Vector2 (3f,1f); // 스마이트 충돌 범위

        Collider2D[] colliders = Physics2D.OverlapBoxAll(playerPosition, detecteArea,0f);

        if(usedSmite ==true && player.FloorCheck()==true) 
        {
            foreach (Collider2D collider in colliders)
            {

                if (collider.gameObject.CompareTag("Monster"))
                {
                    BasicMonster detectedMonster = collider.gameObject.GetComponent<BasicMonster>();

                    if(detectedMonster != null)
                    {
                        detectedMonster.setSturnTime(sturnTime + Mathf.Log(flightTime, 2));
                        usedSmite=false;
                    }
                }
            }
        }
    }
}
