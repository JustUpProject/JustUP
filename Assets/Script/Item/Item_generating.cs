using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_generating :Basic_Item
{
    private GameObject itemPrefab;
    private BasicControler player;

    protected override void Start()
    {
        itemCode = 2;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");

        itemPrefab = Resources.Load<GameObject>("Prefab/object_one_board_M");
    }

    void Update()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            GenerateItem();
        }
    }

    void GenerateItem()
    {
        if (player != null)
        {
            if (player.transform.rotation.y == 0)
            {
                Vector3 playerPosition = player.transform.position;
                Vector3 itemPosition = new Vector3(playerPosition.x - 1f, playerPosition.y - 1f, playerPosition.z);
                Instantiate(itemPrefab, itemPosition, Quaternion.identity);
            }
            else
            {
                Vector3 playerPosition = player.transform.position;
                Vector3 itemPosition = new Vector3(playerPosition.x + 1f, playerPosition.y - 1f, playerPosition.z);
                Instantiate(itemPrefab, itemPosition, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
        }
    }
}
public class ItemColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("아이템이 플레이어와 충돌했습니다!");
        }
    }
}