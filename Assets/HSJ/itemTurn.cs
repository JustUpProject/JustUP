using stateSheild;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemTurn : Basic_Item
{
    // Start is called before the first frame update
    BasicControler player;

    protected override void Start()
    {
        itemCode = 9;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
    }

    private void FixedUpdate()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        player = BasicControler.Instance;


        player.transform.localScale = new Vector3(player.transform.localScale.x * -1, player.transform.localScale.y, player.transform.localScale.z);
        
    }
}
