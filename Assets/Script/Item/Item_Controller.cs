using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    public GameData gameData;
    private static Item_Controller instance;
    private ItemUI item;

    private void Awake()
    {
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
        item = FindObjectOfType<ItemUI>();

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //아이템 스크립트에 함수들 작동
        }

    }
}
