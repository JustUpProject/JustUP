using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Box : MonoBehaviour
{
    private ItemUI itemUi;

    Animator animator;

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        itemUi = FindObjectOfType<ItemUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Mimic_Sence", true);
            StartCoroutine(BoxOpen());

            
        }
            
    }
    
    IEnumerator BoxOpen()
    {
        yield return new WaitForSeconds(0.9f);
        Destroy(transform.parent.gameObject);
        yield return null;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < Item_Controller.Instance.gameData.Inventory.Count; i++)
        {
            if (Item_Controller.Instance.gameData.Inventory[i] == 63)
            {
                Item_Controller.Instance.gameData.Inventory[i] = RandomItem();
                Destroy(this.gameObject);
                itemUi.ItemUpdate();
                break;
            }
        }
    }

    private int RandomItem()
    {
        int itemCode = Random.Range(0, 6);
        if (itemCode == 0)
            return 0;
        else if (itemCode == 1)
            return 3;
        else if (itemCode == 2)
            return 4;
        else if (itemCode == 3)
            return 6;
        else if (itemCode == 4)
            return 8;
        else if (itemCode == 5)
            return 9;
        return 0;
    }
}
