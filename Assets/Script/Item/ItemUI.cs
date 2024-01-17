using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private int currentItem;
    private int currentSlot;

    [SerializeField] private Image slot00;
    [SerializeField] private Image slot01;
    [SerializeField] private Image slot02;

    private Sprite item00;
    private Sprite item01;
    private Sprite item02;
    private Sprite item03;
    private Sprite item04;
    private Sprite item05;
    private Sprite item06;
    private Sprite item07;
    private Sprite item08;
    private Sprite item09;
    private Sprite item10;

    private void Awake()
    {

        item00 = Resources.Load<Sprite>("Image/skill_icon_shield");
        item01 = Resources.Load<Sprite>("Image/Skill_icon_hook");
        item02 = Resources.Load<Sprite>("Image/skill_icon_generating");
        item03 = Resources.Load<Sprite>("Image/skill_icon_Sjump");
        item04 = Resources.Load<Sprite>("Image/skill_icon_smite");
        item06 = Resources.Load<Sprite>("Image/skill_icon_clock");
        item07 = Resources.Load<Sprite>("Image/skill_icon_hide");

        if (item00 == null || item01 == null || item02 == null || item04 == null || item07 == null)
        {
            Debug.Log("이미지 찾지 못함");
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentSlot = 0;
        ItemUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            ItemUpdate();
        }
    }

    public void ItemUpdate()            //아이템 UI Update
    {
        for (int i = 0; i < 3;  i++)
        {
            currentItem = Item_Controller.Instance.gameData.Inventory[i]; 
            if(i == 0) ImageUpdate(currentItem, slot00);
            else if(i == 1) ImageUpdate(currentItem, slot01);
            else if(i == 2) ImageUpdate(currentItem, slot02);
        }
    }

    public void ItemSwap()
    {
        int temp;
        temp = Item_Controller.Instance.gameData.Inventory[0];
        Item_Controller.Instance.gameData.Inventory[0] = Item_Controller.Instance.gameData.Inventory[1]; 
        Item_Controller.Instance.gameData.Inventory[1] = Item_Controller.Instance.gameData.Inventory[2];
        Item_Controller.Instance.gameData.Inventory[2] = temp; 
    }

    private void ImageUpdate(int item, Image icon)
    {
        switch (item)
        {
            case 0:
                icon.sprite = item00;
                break;
            case 1:
                icon.sprite = item01;
                break;
            case 2:
                icon.sprite = item02;
                break;
            case 3:
                icon.sprite = item03;
                break;
            case 4:
                icon.sprite = item04;
                break;
            case 5:
                icon.sprite = item05;
                break;
            case 6:
                icon.sprite = item06;
                break;
            case 7:
                icon.sprite = item07;
                break;
            case 8:
                icon.sprite = item08;
                break;
            case 9:
                icon.sprite = item09;
                break;
            case 63:
                break;
            default:
                Debug.Log("Not Find current Item.");
                break;
        }
    }
}
