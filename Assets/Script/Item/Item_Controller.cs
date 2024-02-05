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

    private void Awake()
    {
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
        item = FindObjectOfType<ItemUI>();
        skill = FindObjectOfType<Basic_Item>();

        if(instance == null)
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
        if(Input.GetKeyDown(KeyCode.I)) 
        {
            if (gameData.Inventory[1] == 0)
            {
                skill = new itemShield();
                skill.UseSkill();
            }
        }

    }
}
