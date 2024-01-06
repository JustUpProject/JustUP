using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Basic_Item : MonoBehaviour
{
    protected GameData gameData;
    protected int itemCode;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        itemCode = 63;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            for (int i = 0; i < gameData.Inventory.Count; i++)
            {
                if (gameData.Inventory[i] == 64)
                {
                    gameData.Inventory[i] = itemCode;
                    Destroy(this.gameObject);
                    Debug.Log("아이템 트리거");
                    break;
                }
            }
        }
    }

}
