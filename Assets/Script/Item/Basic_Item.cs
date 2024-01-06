using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Basic_Item : MonoBehaviour
{
    private ItemUI item;
    protected GameData gameData;
    protected int itemCode;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        itemCode = 62;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
        item = FindObjectOfType<ItemUI>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //if(gameData.Inventory.Contains(64))
            //{
            //    Queue<int> copy = new Queue<int>(3);

            //    for(int i = 0; i < 3; i++)
            //    {
            //        if (gameData.Inventory.Peek() == 64)
            //        {
            //            copy.Enqueue(itemCode);
            //            gameData.Inventory.Dequeue();
            //        }
            //        else
            //        {
            //            copy.Enqueue(gameData.Inventory.Dequeue());
            //        }
            //    }
            //    for (int i = 0; i < 3; i++)
            //    {
            //        gameData.Inventory.Enqueue(copy.Dequeue());
            //    }
            //}
            for (int i = 0; i < gameData.Inventory.Count; i++)
            {
                if (gameData.Inventory[i] == 63)
                {
                    gameData.Inventory[i] = itemCode;
                    Destroy(this.gameObject);
                    item.ItemUpdate();
                    break;
                }
            }
        }
    }

}
