using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Sjump : Basic_Item
{
    [SerializeField] private float jumpPower = 10f;

    protected override void Start()
    {
        itemCode = 3;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
    }

    public override void UseSkill()
    {
        BasicControler.Instance.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
    }
}
