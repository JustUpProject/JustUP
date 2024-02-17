using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    public GameData gameData;
    private static Item_Controller instance;
    private ItemUI item;
    private Basic_Item skill;

    [SerializeField] private itemShield skill00;
    [SerializeField] private Item_Sjump skill03;
    [SerializeField] private itemSmite skill04;
    [SerializeField] private Item_clock skill06;
    [SerializeField] private itemHunt skill08;


    [SerializeField] private GameObject script;

    private void Awake()
    {
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
        item = FindObjectOfType<ItemUI>();
        skill = FindObjectOfType<Basic_Item>();

        skill00 = script.GetComponent<itemShield>();
        skill03 = script.GetComponent<Item_Sjump>();
        skill04 = script.GetComponent<itemSmite>();
        skill06 = script.GetComponent<Item_clock>();
        skill08 = script.GetComponent<itemHunt>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Item_Controller Instance
    {
        get
        {
            return instance;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            item.ItemSwap();
            item.ItemUpdate();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {

            if (gameData.Inventory[1] == 0)
            {
                skill00.UseSkill();
                
            }
            //else if (gameData.Inventory[1] == 1)
            //{
            //    //skill = new Item_hook();
            //    //skill.UseSkill();s
            //}
            //else if (gameData.Inventory[1] == 2)
            //{
            //    skill = new Item_generating();
            //    skill.UseSkill();
            //}
            else if (gameData.Inventory[1] == 3)
            {
                skill03.UseSkill();
            }
            else if (gameData.Inventory[1] == 4)
            {
                skill = new itemSmite();
                skill.UseSkill();
            }
            else if (gameData.Inventory[1] == 5)
            {
                //skill = new Item_teleport();
                //skill.UseSkill();
            }
            else if (gameData.Inventory[1] == 6)
            {
                skill = new Item_clock();
                skill.UseSkill();
            }
            //else if (gameData.Inventory[1] == 7)
            //{
            //    skill = new Item_hide();
            //    skill.UseSkill();
            //}
            else if (gameData.Inventory[1] == 8)
            {
                skill = new itemHunt();
                skill.UseSkill();
            }
            //else if (gameData.Inventory[1] == 9)
            //{
            //    skill = new itemTurn();
            //    skill.UseSkill();
            //}

        }
    }
}
