using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseingItem : MonoBehaviour
{
    private GameData item;
    public GameObject itemGeneratingPrefab;

    private SpriteRenderer effectPrefab;
    private float playerOriginMovingSpeed;
    [SerializeField] private float jumpPower = 10f;
    public bool UseItem;
    public bool ItemActivate;
    public bool ItemHunted;

    // Start is called before the first frame update
    void Start()
    {
        item = Item_Controller.Instance.gameData;
        effectPrefab = BasicControler.Instance.transform.Find("Circle").gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            
            if (item.Inventory[1] == 0)
            {
                initShield();
                item.Inventory[1] = 63;
                Item_Controller.Instance.item.ItemUpdate();
                StartCoroutine(Useing());
                
            }
            else if (item.Inventory[1] == 2)
            {
                item.Inventory[1] = 63;
                Item_Controller.Instance.item.ItemUpdate();
                if (BasicControler.Instance != null)
                {
                    if (BasicControler.Instance.transform.rotation.y == 0)
                    {
                        Vector3 playerPosition = BasicControler.Instance.transform.position;
                        Vector3 itemPosition = new Vector3(playerPosition.x - 1f, playerPosition.y - 1f, playerPosition.z);
                        Instantiate(itemGeneratingPrefab, itemPosition, Quaternion.identity);
                    }
                    else
                    {
                        Vector3 playerPosition = BasicControler.Instance.transform.position;
                        Vector3 itemPosition = new Vector3(playerPosition.x + 1f, playerPosition.y - 1f, playerPosition.z);
                        Instantiate(itemGeneratingPrefab, itemPosition, Quaternion.identity);
                    }
                }
            }
            else if (item.Inventory[1] == 3)
            {
                item.Inventory[1] = 63;
                Item_Controller.Instance.item.ItemUpdate();
                BasicControler.Instance.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
            }
            else if (item.Inventory[1] == 4)
            {

            }
            else if (item.Inventory[1] == 6)
            {

            }
            else if (item.Inventory[1] == 8)
            {
                initHunt();
                item.Inventory[1] = 63;
                Item_Controller.Instance.item.ItemUpdate();
                StartCoroutine(itemHunt());
            }
            else if (item.Inventory[1] == 9)
            {

            }
        }
    }
    void initShield()
    {
        UseItem = true;
        ItemActivate = true;
        if (effectPrefab == null)
            Debug.Log("못찾음");
    }

    void initHunt()
    {
        ItemHunted = true;
        playerOriginMovingSpeed = BasicControler.Instance.moveSpeed;
        BasicControler.Instance.moveSpeed = BasicControler.Instance.moveSpeed * 1.3f;
    }

    IEnumerator itemHunt()
    {
        yield return new WaitForSeconds(5.0f);

        ItemHunted = false;
        BasicControler.Instance.moveSpeed = playerOriginMovingSpeed; 

        yield return null;
    }
    IEnumerator Useing()
    {
        Debug.Log("아이템");
        effectPrefab.enabled = true;
        yield return new WaitForSeconds(3.0f);

        ItemActivate = false;

        if (UseItem == false)
        {
            effectPrefab.enabled = false;
            yield return null;
        }

        effectPrefab.enabled = false;

        yield return null;
    }
}
//if (Input.GetKeyDown(KeyCode.I))
//{

//    if (gameData.Inventory[1] == 0)
//    {
//        skill00.UseSkill();

//    }
//    //else if (gameData.Inventory[1] == 1)
//    //{
//    //    //skill = new Item_hook();
//    //    //skill.UseSkill();s
//    //}
//    //else if (gameData.Inventory[1] == 2)
//    //{
//    //    skill = new Item_generating();
//    //    skill.UseSkill();
//    //}
//    else if (gameData.Inventory[1] == 3)
//    {
//        skill03.UseSkill();
//    }
//    else if (gameData.Inventory[1] == 4)
//    {
//        skill = new itemSmite();
//        skill.UseSkill();
//    }
//    else if (gameData.Inventory[1] == 5)
//    {
//        //skill = new Item_teleport();
//        //skill.UseSkill();
//    }
//    else if (gameData.Inventory[1] == 6)
//    {
//        skill = new Item_clock();
//        skill.UseSkill();
//    }
//    //else if (gameData.Inventory[1] == 7)
//    //{
//    //    skill = new Item_hide();
//    //    skill.UseSkill();
//    //}
//    else if (gameData.Inventory[1] == 8)
//    {
//        skill = new itemHunt();
//        skill.UseSkill();
//    }
//    //else if (gameData.Inventory[1] == 9)
//    //{
//    //    skill = new itemTurn();
//    //    skill.UseSkill();
//    //}

//}