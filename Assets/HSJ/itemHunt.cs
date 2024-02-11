using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StatHunt
{
    before,
    ing,
    after
}
public class itemHunt : Basic_Item
{
    StatHunt hunt;

    private float huntTime = 5.0f;
    float playerOriginMoveSpeed;

    protected override void Start()
    {
        itemCode = 8;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
    }

    private void Update()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        switch (hunt)
        {
            case StatHunt.before:
                if (Input.GetKeyUp(KeyCode.I))
                {
                    huntTime = 5.0f;
                    playerOriginMoveSpeed = BasicControler.Instance.moveSpeed;
                    BasicControler.Instance.moveSpeed = BasicControler.Instance.moveSpeed * 1.3f;
                    hunt = StatHunt.ing;
                }
                break;

            case StatHunt.ing:
                if(huntTime < 0f)
                {
                    BasicControler.Instance.moveSpeed = playerOriginMoveSpeed;
                    hunt = StatHunt.after;
                }
                else
                {
                    huntTime -= Time.deltaTime;
                }
                break;

            case StatHunt.after:
                BasicControler.Instance.moveSpeed = playerOriginMoveSpeed;
                hunt = StatHunt.before;
                break;
        }
    }
}
