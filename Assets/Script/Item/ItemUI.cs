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

    private Image item00;
    private Image item01;
    private Image item02;
    private Image item03;
    private Image item04;
    private Image item05;
    private Image item06;
    private Image item07;
    private Image item08;
    private Image item09;
    private Image item10;

    private void Awake()
    {
        item00 = Resources.Load<Image>("Image/skill_icon_shield");
        item01 = Resources.Load<Image>("Image/skill_icon_hook");
        item02 = Resources.Load<Image>("Image/skill_icon_generating");
        item04 = Resources.Load<Image>("Image/skill_icon_smite");
        item07 = Resources.Load<Image>("Image/skill_icon_hide");
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
        
    }

    public void ItemUpdate()            //아이템 UI Update
    {
        for (int i = 0; i < 3;  i++)
        {
            currentItem = Item_Controller.Instance.gameData.Inventory[i]; //// ㅈ버그 발생 레퍼런스 못 찾음
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
                icon.sprite = item00.sprite;
                break;
            case 1:
                icon.sprite = item01.sprite;
                break;
            case 2:
                icon.sprite = item02.sprite;
                break;
            case 3:
                break;
            case 4:
                icon.sprite = item04.sprite;
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                icon.sprite = item07.sprite;
                break;
            case 8:
                break;
            case 9:
                break;
            case 63:
                break;
            default:
                Debug.Log("Not Find current Item.");
                break;
        }
    }
}
