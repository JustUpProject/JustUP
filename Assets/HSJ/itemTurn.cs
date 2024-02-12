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

        if (Input.GetKeyUp(KeyCode.I))
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
    }
}
