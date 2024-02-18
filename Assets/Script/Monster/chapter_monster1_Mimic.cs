using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter_monster1_Mimic : BasicMonster
{
    private ItemUI itemUi;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        itemUi = FindObjectOfType<ItemUI>();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        Debug.Log("Drop");
        for (int i = 0; i < Item_Controller.Instance.gameData.Inventory.Count; i++)
        {
            if (Item_Controller.Instance.gameData.Inventory[i] == 63)
            {
                Item_Controller.Instance.gameData.Inventory[i] = RandomItem();
                Destroy(this.gameObject);
                itemUi.ItemUpdate();
                break;
            }
        }
    }

    private int RandomItem()
    {
        int itemCode = Random.Range(0, 6);
        if (itemCode == 0)
            return 0;
        else if (itemCode == 1)
            return 3;
        else if (itemCode == 2)
            return 4;
        else if (itemCode == 3)
            return 6;
        else if (itemCode == 4)
            return 8;
        else if (itemCode == 5)
            return 9;
        return 0;
    }
}
