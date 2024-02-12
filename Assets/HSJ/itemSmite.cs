using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatSmite
{
    jump,
    flight,
    sturn
}

public class itemSmite : Basic_Item
{
    StatSmite smite;
    private Rigidbody2D playerRig;

    [SerializeField] private float jumpPower = 2.5f;

    private float flightTime = 0.1f;
    private float sturnTime = 0.5f;

    protected override void Start()
    {
        itemCode = 4;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
    }

    private void Update()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        switch (smite)
        {
            case StatSmite.jump:
                if (Input.GetKeyUp(KeyCode.I))
                {
                    jump();
                    Debug.Log("smite On");
                }
                break;
            case StatSmite.flight:
                flight();
                break;
            case StatSmite.sturn:
                sturn();
                break;
            default:
                // Handle the case where an unexpected value is assigned to smite
                Debug.LogError("Unexpected value for smite enum: " + smite);
                break;
        }
    }

    private void jump()
    {
        playerRig = BasicControler.Instance.GetComponent<Rigidbody2D>();

        playerRig.gravityScale = 1;
        playerRig.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        smite = StatSmite.flight;
    }

    private void flight()
    {
        if (BasicControler.Instance.FloorCheck() == true)
        {
            smite = StatSmite.sturn;
        }
        else
        {
            flightTime += Time.deltaTime;
        }
    }

    private void sturn()
    {
        Vector2 playerPosition = BasicControler.Instance.transform.position;
        Vector2 detecteArea = new Vector2(3f, 1f); // 스마이트 충돌 범위

        Collider2D[] colliders = Physics2D.OverlapBoxAll(playerPosition, detecteArea, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Monster"))
            {
                BasicMonster detectedMonster = collider.gameObject.GetComponent<BasicMonster>();

                if (detectedMonster != null)
                {
                    detectedMonster.setSturnTime(sturnTime + Mathf.Log(flightTime, 2));
                    smite = StatSmite.jump;
                }
            }
        }
    }
}
