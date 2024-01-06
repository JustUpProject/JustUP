using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_generating : MonoBehaviour
{
    public GameObject itemPrefab;
    private BasicControler player;
    private void Awake()
    {
        player = FindObjectOfType<BasicControler>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
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